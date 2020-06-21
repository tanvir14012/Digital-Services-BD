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
        public CartItemViewModel AddCartItemtoCart(int? cartId, int? userId, int productItemId, int quantity)
        {
            CartItemViewModel cartItemViewModel = new CartItemViewModel();
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
                                              join productItemBundleProductItemMap in context.productItemBundleJoinProductItems
                                              on productItemBundle.Id equals productItemBundleProductItemMap.ProductItemBundleId
                                              join productItem in context.ProductItems
                                              on productItemBundleProductItemMap.ProductItemId equals productItem.Id
                                              join price in context.ProductItemPrices
                                              on productItem.Id equals price.ProductItemId
                                              where price.PriceCurrency == "BDT"
                                              select new
                                              {
                                                  productItemBundle,
                                                  productItemBundleProductItemMap,
                                                  productItem,
                                                  price
                                              };

                var bundleList = new List<CartItemBundleViewModel>();
                decimal subtotal = 0;
                foreach(var bundleObj in populateCartItemBundles.ToList())
                {
                    var bundleViewModel = new CartItemBundleViewModel();
                    bundleViewModel.Name = bundleObj.productItemBundle.Name;
                    bundleViewModel.BundleDiscount = bundleObj.productItemBundle.BundleDiscount;
                    bundleViewModel.BundlePrice += (bundleObj.price.Price - bundleObj.price.Discount + bundleObj.price.Vat) * 
                        bundleObj.productItemBundleProductItemMap.ProductItemQuantity;
                    bundleViewModel.IndividualItemsView.Add(new ProductItemBundleIndividualItemView { 
                        ProductItemName = bundleObj.productItem.Name,
                        Quantity = bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                        Price = bundleObj.price.Price * bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                        Discount = bundleObj.price.Discount * bundleObj.productItemBundleProductItemMap.ProductItemQuantity,
                        Vat = bundleObj.price.Vat * bundleObj.productItemBundleProductItemMap.ProductItemQuantity
                    });
                    subtotal += (bundleViewModel.BundlePrice - bundleViewModel.BundleDiscount);
                    bundleList.Add(bundleViewModel);
                }
                cartViewModel = new CartViewModel
                {
                    CartId = cart.Id,
                    UserId = cart.UserId,
                    CartItems = populateCartItems.ToList(),
                    CartItemBundlesViewModel = bundleList,
                    PromoCode = null,
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
    }
}
