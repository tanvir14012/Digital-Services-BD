using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class CartOps : ICartOps
    {
        private readonly AppDbContext context;

        public CartOps(AppDbContext context)
        {
            this.context = context;
        }
        public Cart CreateCart(int? userId)
        {
            var cart = new Cart
            {
                UserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            context.Carts.Add(cart);

            try
            {
                context.SaveChanges();
                return cart;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public AddCartItemViewModel AddCartItemtoCart(int? cartId, int? userId, int productItemId, int quantity)
        {
            AddCartItemViewModel cartItemViewModel = new AddCartItemViewModel();
            Cart cart = null;
            
            if (userId != null)
            {
                cart = context.Carts.Where(c => c.UserId == userId).OrderByDescending(c => c.CreatedOn).FirstOrDefault();
            }
            else if (cartId != null)
            {
                cart = context.Carts.Find(cartId);
            }
            //No cart found
            if (cart == null)
            {
                cart = CreateCart(userId);
                cartItemViewModel.IsCartCreatedWhenAdded = true;
                cartItemViewModel.CreatedCartId = cart.Id;
            }
            var productItem = context.ProductItems.Find(productItemId);
            if(cart != null && productItem != null && quantity > 0)
            {
                //var price = context.ProductItemPrices.Where(p => p.ProductItemId == productItem.Id && p.PriceCurrency == "BDT").FirstOrDefault();
                if(! DoesProductItemExistInCart(cart.Id, productItem.Id))
                {
                    var cartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductItemId = productItem.Id,
                        Quantity = quantity
                    };
                    context.CartItems.Add(cartItem);
                    try
                    {
                        context.SaveChanges();
                        cartItemViewModel.CartItem = cartItem;
                        return cartItemViewModel;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
                else //In cart there exists the product item already
                {
                    var cartItem = context.CartItems.Where(ci => ci.CartId == cart.Id && ci.ProductItemId == productItem.Id).FirstOrDefault();
                    if(cartItem != null)
                    {
                        cartItem.Quantity += quantity;
                        if(cartItem.Quantity > ProductConfig.MaxItemAllowedInCart)
                        {
                            cartItem.Quantity = ProductConfig.MaxItemAllowedInCart;
                            cartItemViewModel.Message = $"We are glad that you like to buy a lot of stuffs but the possible maximum quantity of a product in cart is {ProductConfig.MaxItemAllowedInCart}, that is added to your cart.";
                            cartItemViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                        }
                        context.CartItems.Update(cartItem);
                        try
                        {
                            context.SaveChanges();
                            cartItemViewModel.CartItem = cartItem;
                            return cartItemViewModel;
                        }
                        catch (Exception e)
                        {
                            return null;
                        }
                    }
                }
               
               
            }
            return null;
        }

        public CartItem DeleteCartItemFromCart(int cartId, int cartItemId)
        {
            var cart = context.Carts.Find(cartId);
            var cartItem = context.CartItems.Find(cartItemId);
            if(cart != null && cartItem != null)
            {
                context.CartItems.Remove(cartItem);
                try
                {
                    context.SaveChanges();
                    return cartItem;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public bool EmptyCart(int cartId)
        {
            var cart = context.Carts.Find(cartId);
            if(cart != null)
            {
                context.CartItems.RemoveRange(context.CartItems.Where(item => item.CartId == cart.Id));
                context.CartJoinProductItemBundles.RemoveRange(context.CartJoinProductItemBundles.Where(j => j.CartId == cartId));
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public Cart MergeCarts(int anonymousCartId, int userId)
        {
            var anonymousCart = context.Carts.Find(anonymousCartId);
            var userCart = context.Carts.Where(c => c.UserId == userId).FirstOrDefault();
            if(anonymousCart != null && userCart != null)
            {
                var anonymousCartItems = context.CartItems.Where(item => item.CartId == anonymousCart.Id);
                foreach(var item in anonymousCartItems)
                {
                    item.CartId = userCart.Id;
                }
                try
                {
                    context.SaveChanges();
                    return userCart;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public CartItem UpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = context.CartItems.Find(cartItemId);
            if(cartItem != null && quantity > 0)
            {
                quantity = quantity > ProductConfig.MaxItemAllowedInCart ? ProductConfig.MaxItemAllowedInCart : quantity;
                cartItem.Quantity = quantity;
                context.CartItems.Update(cartItem);
            }
            try
            {
                context.SaveChanges();
                return cartItem;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CartViewModel GetCart(int? cartId, int? userId)
        {
            CartViewModel cartViewModel = null;
            Cart cart = null;
            if (userId != null)
            {
                cart = context.Carts.Where(c => c.UserId == userId).OrderByDescending(c => c.CreatedOn).FirstOrDefault();
            }
            else if (cartId != null)
            {
                cart = context.Carts.Find(cartId);
            }
            //If cart found in database
            if (cart != null)
            {
                var populateCartItems = from cartItem in context.CartItems
                            join productItem in context.ProductItems
                            on cartItem.ProductItemId equals productItem.Id
                            where cartItem.CartId == cart.Id
                            join price in context.ProductItemPrices
                            on productItem.Id equals price.ProductItemId
                            where price.PriceCurrency == "BDT"
                            select new CartItem {
                                Id= cartItem.Id,
                                Name = productItem.Name,
                                ProductItemId = productItem.Id,
                                CartId = cartItem.CartId,
                                Quantity = cartItem.Quantity,
                                Price = price.Price * cartItem.Quantity,
                                Discount = price.Discount * cartItem.Quantity,
                                Vat = price.Vat * cartItem.Quantity,
                                PriceCurrency = price.PriceCurrency
                            };
                var populateCartItemBundles = from productItemBundle in context.ProductItemBundles
                                              join cartProductItemBundleMap in context.CartJoinProductItemBundles
                                              on productItemBundle.Id equals cartProductItemBundleMap.ProductItemBundleId
                                              where cartProductItemBundleMap.CartId == cart.Id
                                              select productItemBundle;

                var bundleList = new List<CartItemBundleViewModel>();
                decimal subtotal = populateCartItems.Distinct().Sum(ci => ci.Price - ci.Discount + ci.Vat);
                foreach (var productItemBundle in populateCartItemBundles.ToList())
                {
                    var bundleViewModel = new CartItemBundleViewModel();
                    bundleViewModel.ProductItemBundleId = productItemBundle.Id;
                    bundleViewModel.Name = productItemBundle.Name;
                    bundleViewModel.Quantity = (int) context.CartJoinProductItemBundles.Where(j => j.CartId == cart.Id && j.ProductItemBundleId == productItemBundle.Id).FirstOrDefault()?.Quantity;
                    bundleViewModel.PriceCurrency = "BDT";
                    bundleViewModel.BundleDiscount = productItemBundle.BundleDiscount;
                    var bundleProductItems = from productItemBundleProductItemMap in context.productItemBundleJoinProductItems
                                             join productItem2 in context.ProductItems
                                             on productItemBundleProductItemMap.ProductItemId equals productItem2.Id
                                             where productItemBundleProductItemMap.ProductItemBundleId == productItemBundle.Id
                                             join price in context.ProductItemPrices
                                             on productItem2.Id equals price.ProductItemId
                                             where price.PriceCurrency == "BDT"
                                             select new {productItemBundleProductItemMap, productItem2, price};
                    
                    foreach(var bundleObj in bundleProductItems.Distinct().ToList())
                    {
                        bundleViewModel.IndividualItemsView.Add(new ProductItemBundleIndividualItemView
                        {
                            ProductItemName = bundleObj.productItem2.Name,
                            Quantity = bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                            Price = bundleObj.price.Price * bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                            Discount = bundleObj.price.Discount * bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                            Vat = bundleObj.price.Vat * bundleObj.productItemBundleProductItemMap.ProductItemQuantity
                        });
                        bundleViewModel.BundlePrice += (bundleObj.price.Price - bundleObj.price.Discount + bundleObj.price.Vat) *
                        bundleObj.productItemBundleProductItemMap.ProductItemQuantity;
                    }
                   
                    subtotal += (bundleViewModel.BundlePrice - bundleViewModel.BundleDiscount) * bundleViewModel.Quantity;
                    bundleList.Add(bundleViewModel);
                }
                cartViewModel = new CartViewModel
                {
                    CartId = cart.Id,
                    UserId = cart.UserId,
                    CartItems = populateCartItems.ToList(),
                    CartItemBundlesViewModel = bundleList,
                    PromoCode = null,
                    PriceCurrency = populateCartItems.Distinct().ToList().FirstOrDefault()?.PriceCurrency,
                    PromoCodeDiscount = 0,
                    Subtotal = subtotal,
                    TaxesAndFees = 0,
                    Total = subtotal - 0
                };
            }
            else //Cart not found in database, so create one
            {
                var newCart = CreateCart(userId);
                if(newCart != null)
                {
                    cartViewModel = new CartViewModel
                    {
                        CartId = newCart.Id,
                        UserId = userId,
                        IsCreatedNow = true
                    };
                }
            }
            return cartViewModel;
        }

        public bool DoesCartExist(int cartId)
        {
            return context.Carts.AsNoTracking().Where(c => c.Id == cartId).Count() > 0;
        }

        private bool DoesProductItemExistInCart(int cartId, int productItemId)
        {
            return context.CartItems.Where(ci => ci.CartId == cartId && ci.ProductItemId == productItemId).Count() > 0;
        }
        private bool DoesProductItemBundleExistInCart(int cartId, int productItemBundleId)
        {
            var bundles = from prodItmBundles in context.ProductItemBundles
                          join cartJoinProductItemBundle in context.CartJoinProductItemBundles
                          on prodItmBundles.Id equals cartJoinProductItemBundle.ProductItemBundleId
                          where cartJoinProductItemBundle.CartId == cartId
                          select prodItmBundles;
            return bundles.ToList().Count() > 0;
        }

        public AddCartItemBundleViewModel AddProductItemBundletoCart(int? cartId, int? userId, int productItemBundleId, int quantity)
        {
            AddCartItemBundleViewModel cartItemBundleViewModel = new AddCartItemBundleViewModel();
            Cart cart = null;

            if (userId != null)
            {
                cart = context.Carts.Where(c => c.UserId == userId).OrderByDescending(c => c.CreatedOn).FirstOrDefault();
            }
            else if (cartId != null)
            {
                cart = context.Carts.Find(cartId);
            }
            //No cart found
            if (cart == null)
            {
                cart = CreateCart(userId);
                cartItemBundleViewModel.IsCartCreatedWhenAdded = true;
                cartItemBundleViewModel.CreatedCartId = cart.Id;
            }
            var productItemBundle = context.ProductItemBundles.Find(productItemBundleId);
            if (cart != null && productItemBundle != null && quantity > 0)
            {
                if (!DoesProductItemBundleExistInCart(cart.Id, productItemBundle.Id))
                {
                    var cartJoincartItemBundle = new CartJoinProductItemBundle
                    {
                        CartId = cart.Id,
                        ProductItemBundleId = productItemBundle.Id,
                        Quantity = quantity
                    };
                    context.CartJoinProductItemBundles.Add(cartJoincartItemBundle);
                    try
                    {
                        context.SaveChanges();
                        cartItemBundleViewModel.ProductItemBundle = productItemBundle;
                        return cartItemBundleViewModel;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
                else //In cart there exists the product item bundle already
                {
                    var cartJoinProductItemBundle = context.CartJoinProductItemBundles.Where(j => j.CartId == cart.Id && j.ProductItemBundleId == productItemBundle.Id).FirstOrDefault();
                    if (cartJoinProductItemBundle != null)
                    {
                        cartJoinProductItemBundle.Quantity += quantity;
                        if (cartJoinProductItemBundle.Quantity > ProductConfig.MaxItemAllowedInCart)
                        {
                            cartJoinProductItemBundle.Quantity = ProductConfig.MaxItemAllowedInCart;
                            cartItemBundleViewModel.Message = $"We are glad that you like to buy a lot of stuffs but the " +
                                $"possible maximum quantity of a product in cart is {ProductConfig.MaxItemAllowedInCart}, that" +
                                $" is added to your cart.";
                            cartItemBundleViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                        }
                        context.CartJoinProductItemBundles.Update(cartJoinProductItemBundle);
                        try
                        {
                            context.SaveChanges();
                            cartItemBundleViewModel.ProductItemBundle = productItemBundle;
                            return cartItemBundleViewModel;
                        }
                        catch (Exception e)
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        public bool DeleteProductItemBundleFromCart(int cartId, int productItemBundleId)
        {
            var cart = context.Carts.Find(cartId);
            var bundle = context.ProductItemBundles.Find(productItemBundleId);
            if (cart != null && bundle != null)
            {
                context.CartJoinProductItemBundles.Remove(context.CartJoinProductItemBundles
                    .Where(j => j.CartId == cartId && j.ProductItemBundleId == productItemBundleId).FirstOrDefault());
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public CartJoinProductItemBundle UpdateProductItemBundleQuantity(int cartId, int productItemBundleId, int quantity)
        {
            var joinTable = context.CartJoinProductItemBundles
                .Where(j => j.CartId == cartId && j.ProductItemBundleId == productItemBundleId).FirstOrDefault();
            if (joinTable != null && quantity > 0)
            {
                quantity = quantity > ProductConfig.MaxItemAllowedInCart ? ProductConfig.MaxItemAllowedInCart : quantity;
                joinTable.Quantity = quantity;
                context.CartJoinProductItemBundles.Update(joinTable);
            }
            try
            {
                context.SaveChanges();
                return joinTable;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
