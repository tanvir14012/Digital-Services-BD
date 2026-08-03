using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace Digital_Services_BD.Services
{
    public class CartOps : ICartOps
    {
        private readonly AppDbContext context;

        public CartOps(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Cart> CreateCart(string userId)
        {
            var cart = await context.Carts.AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow
                };

                await context.Carts.AddAsync(cart);

                try
                {
                    await context.SaveChangesAsync();
                    return cart;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return cart;
        }
        public async Task<AddCartItemViewModel> AddCartItemtoCart(int cartId, string userId, int productItemId, int quantity)
        {
            AddCartItemViewModel cartItemViewModel = new AddCartItemViewModel();

            var cart = await context.Carts.AsNoTracking().Include(c => c.CartProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                        .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                            .ThenInclude(join => join.ProductItem)
                    .Where(c => c.Id == cartId).FirstOrDefaultAsync();

            //No cart found
            if (cart == null)
            {
                cart = await CreateCart(userId);
                cartItemViewModel.IsCartCreatedWhenAdded = true;
                cartItemViewModel.CreatedCartId = cart.Id;
            }

            var productItem = await context.ProductItems
                .Include(item => item.ProductStockCount).FirstOrDefaultAsync(item => item.Id == productItemId);

            if (cart != null && productItem != null && quantity > 0 && productItem.ProductStockCount.Count > 0)
            {
                int countInBundle = 0;
                if (cart.CartProductItemBundles.Any())
                {
                    countInBundle = cart.CartProductItemBundles
                        .Sum(bundle => bundle.Quantity * (bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                        .FirstOrDefault(join => join.ProductItemId == productItem.Id)
                        ?.ProductItemQuantity ?? 0));
                }

                //If the item is not in cart
                if (!await DoesProductItemExistInCart(cart.Id, productItem.Id))
                {
                    var cartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductItemId = productItem.Id,
                        Quantity = (productItem.ProductStockCount.Count - countInBundle) >= quantity
                        ? quantity : (productItem.ProductStockCount.Count - countInBundle)
                    };

                    if (cartItem.Quantity <= 0)
                    {
                        return null;
                    }

                    await context.CartItems.AddAsync(cartItem);

                    try
                    {
                        await context.SaveChangesAsync();
                        cartItemViewModel.CartItem = cartItem;
                        if (productItem.ProductStockCount.Count < quantity)
                        {
                            cartItemViewModel.Message = $"Sorry, we have a shortage of the item, the available quantity is {productItem.ProductStockCount.Count} and added to your cart.";
                            cartItemViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                        }
                        return cartItemViewModel;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
                else //In cart there exists the product item already
                {
                    var cartItem = await context.CartItems
                        .Include(ci => ci.ProductItem)
                            .ThenInclude(pi => pi.ProductStockCount)
                        .Where(ci => ci.CartId == cart.Id && ci.ProductItemId == productItem.Id)
                        .FirstOrDefaultAsync();

                    if (cartItem != null)
                    {
                        cartItem.Quantity += quantity;
                        if (cartItem.Quantity > cartItem.ProductItem.ProductStockCount.Count - countInBundle)
                        {
                            cartItem.Quantity = cartItem.ProductItem.ProductStockCount.Count - countInBundle;
                            cartItemViewModel.Message = $"Sorry, we have a shortage of the item, the available quantity is {cartItem.ProductItem.ProductStockCount.Count} and added to your cart.";
                            cartItemViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                        }

                        if (cartItem.Quantity > ProductConfig.MaxItemAllowedInCart)
                        {
                            cartItem.Quantity = ProductConfig.MaxItemAllowedInCart;
                            cartItemViewModel.Message = $"We are glad that you like to buy a lot of stuffs but the maximum quantity of a product in cart is {ProductConfig.MaxItemAllowedInCart}, that is added to your cart.";
                            cartItemViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                        }

                        if (cartItem.Quantity <= 0)
                        {
                            return null;
                        }

                        try
                        {
                            await context.SaveChangesAsync();
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

        public async Task<CartItem> DeleteCartItemFromCart(int cartId, int cartItemId)
        {
            var cartItem = new CartItem { Id = cartItemId };
            context.CartItems.Remove(cartItem);
            try
            {
                await context.SaveChangesAsync();
                return cartItem;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> EmptyCart(int cartId)
        {
            var cartExists = await context.Carts.AsNoTracking().AnyAsync(c => c.Id == cartId);

            if (cartExists)
            {
                try
                {
                    context.Carts.Remove(new Cart { Id = cartId });
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<Cart> MergeCarts(int anonymousCartId, string userId)
        {
            try
            {
                var anonymousCart = await context.Carts.Include(c => c.CartItems)
                            .ThenInclude(ci => ci.ProductItem)
                                .ThenInclude(pi => pi.ProductStockCount)
                        .Include(c => c.CartProductItemBundles)
                            .ThenInclude(bundle => bundle.ProductItemBundle)
                                .ThenInclude(bundle => bundle.ProductItemBundleJoinProductItem)
                                    .ThenInclude(join => join.ProductItem)
                                        .ThenInclude(pi => pi.ProductStockCount)
                        .FirstOrDefaultAsync(c => c.Id == anonymousCartId);

                var userCart = await context.Carts.Include(c => c.CartItems)
                        .ThenInclude(ci => ci.ProductItem)
                            .ThenInclude(pi => pi.ProductStockCount)
                    .Include(c => c.CartProductItemBundles)
                        .ThenInclude(bundle => bundle.ProductItemBundle)
                            .ThenInclude(bundle => bundle.ProductItemBundleJoinProductItem)
                                .ThenInclude(join => join.ProductItem)
                                    .ThenInclude(pi => pi.ProductStockCount)
                        .Where(c => c.UserId == userId).FirstOrDefaultAsync();

                if (anonymousCart != null && userCart != null && anonymousCart.Id != userCart.Id)
                {
                    //Items
                    foreach (var item in anonymousCart.CartItems)
                    {
                        //Merge quantity if same item already exists
                        if (userCart.CartItems.Any(cartItem => cartItem.ProductItemId == item.ProductItemId))
                        {
                            var cartItem = userCart.CartItems.First(cItem => cItem.ProductItemId == item.ProductItemId);
                            cartItem.Quantity += item.Quantity;
                            if (cartItem.Quantity > cartItem.ProductItem.ProductStockCount.Count)
                            {
                                cartItem.Quantity = cartItem.ProductItem.ProductStockCount.Count;
                                if (cartItem.Quantity <= 0)
                                {
                                    userCart.CartItems.Remove(cartItem);
                                }
                            }
                            if (cartItem.Quantity > ProductConfig.MaxItemAllowedInCart)
                            {
                                cartItem.Quantity = ProductConfig.MaxItemAllowedInCart;
                            }
                        }
                        else
                        {
                            item.CartId = userCart.Id;
                            userCart.CartItems.Add(item);
                        }

                    }

                    //Bundle items
                    foreach (var bundle in anonymousCart.CartProductItemBundles)
                    {
                        //Merge quantity if same bundle already exists
                        if (userCart.CartProductItemBundles.Any(bndl => bndl.ProductItemBundleId == bundle.ProductItemBundleId))
                        {
                            var userCartBundle = userCart.CartProductItemBundles.First(bndl => bndl.ProductItemBundleId == bundle.ProductItemBundleId);
                            userCartBundle.Quantity += bundle.Quantity;
                            var minStock = bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                                .Min(join => join.ProductItem.ProductStockCount.Count / join.ProductItemQuantity) / bundle.Quantity;
                            if (userCartBundle.Quantity > minStock)
                            {
                                userCartBundle.Quantity = minStock;
                                if (minStock <= 0)
                                {
                                    userCart.CartProductItemBundles.Remove(userCartBundle);
                                }
                            }
                            if (userCartBundle.Quantity > ProductConfig.MaxItemAllowedInCart)
                            {
                                userCartBundle.Quantity = ProductConfig.MaxItemAllowedInCart;
                            }
                        }
                        else
                        {
                            bundle.CartId = userCart.Id;
                            userCart.CartProductItemBundles.Add(bundle);
                        }
                    }

                    context.Carts.Remove(anonymousCart);
                    await context.SaveChangesAsync();
                    return userCart;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<CartItem> UpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = await context.CartItems
                .Include(ci => ci.Cart)
                .ThenInclude(c => c.CartProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                        .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                .Include(ci => ci.ProductItem)
                    .ThenInclude(pi => pi.ProductStockCount)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId);


            if (cartItem != null)
            {
                try
                {
                    int countInBundle = 0;
                    if (cartItem.Cart.CartProductItemBundles.Any())
                    {
                        countInBundle = cartItem.Cart.CartProductItemBundles
                            .Sum(bundle => bundle.Quantity * (bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                            .FirstOrDefault(join => join.ProductItemId == cartItem.ProductItemId)
                            ?.ProductItemQuantity ?? 0));
                    }

                    if (quantity > cartItem.ProductItem.ProductStockCount.Count - countInBundle)
                    {
                        quantity = cartItem.ProductItem.ProductStockCount.Count - countInBundle;
                    }

                    quantity = quantity > ProductConfig.MaxItemAllowedInCart ? ProductConfig.MaxItemAllowedInCart : quantity;
                    cartItem.Quantity = quantity;
                    if (cartItem.Quantity <= 0)
                    {
                        context.CartItems.Remove(cartItem);
                    }

                    await context.SaveChangesAsync();
                    return cartItem;
                }
                catch { }
            }

            return cartItem;
        }

        public async Task<CartViewModel> GetCart(int? cartId)
        {
            CartViewModel cartViewModel = null;
            var cart = await context.Carts.Where(c => c.Id == cartId)
                                    .Include(c => c.CartItems)
                                        .ThenInclude(cartItem => cartItem.ProductItem)
                                            .ThenInclude(productItem => productItem.ProductItemPrice)
                                    .Include(c => c.CartItems)
                                        .ThenInclude(cartItem => cartItem.ProductItem)
                                            .ThenInclude(productItem => productItem.ProductStockCount)
                                    .Include(c => c.CartProductItemBundles)
                                        .ThenInclude(cartbundle => cartbundle.ProductItemBundle)
                                            .ThenInclude(bundle => bundle.ProductItemBundleJoinProductItem)
                                                .ThenInclude(join => join.ProductItem)
                                                    .ThenInclude(prodItem => prodItem.ProductItemPrice)
                                    .Include(c => c.CartProductItemBundles)
                                        .ThenInclude(cartbundle => cartbundle.ProductItemBundle)
                                            .ThenInclude(bundle => bundle.ProductItemBundleJoinProductItem)
                                                .ThenInclude(join => join.ProductItem)
                                                    .ThenInclude(prodItem => prodItem.ProductStockCount)
                                    .FirstOrDefaultAsync();


            //If cart found in database
            if (cart != null)
            {
                //Remove cartItems with 0 quantity/out of stock items
                string message = null;
                var outOfStockItems = PopulateOutOfStockCartProductItems(cart);
                if (outOfStockItems.Any())
                {
                    cart = await RemoveOutOfStockItemsFromGivenCart(cart);
                    message = "One or more items in your cart went out of stock." +
                        " Some items may have been removed or the quantity has been reduced. We sincerely apologize for this inconvenience.";
                }

                //Remove out of stock items


                cartViewModel = new CartViewModel
                {
                    CartId = cart.Id,
                    UserId = cart.UserId,
                    CartItems = cart.CartItems,
                    CartItemBundlesViewModel = cart.CartProductItemBundles.Select(bundle =>
                    new CartItemBundleViewModel
                    {
                        ProductItemBundleId = bundle.ProductItemBundleId,
                        Name = bundle.ProductItemBundle.Name,
                        Quantity = bundle.Quantity,
                        BundleDiscount = bundle.ProductItemBundle.BundleDiscount +
                            (decimal)bundle.ProductItemBundle.ProductItemBundleJoinProductItem.Sum(join =>
                           join.ProductItemQuantity * (join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Discount)),

                        BundlePrice = (decimal)bundle.ProductItemBundle.ProductItemBundleJoinProductItem.Sum(join =>
                            join.ProductItemQuantity * (join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Price
                            + join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Vat)),

                        PriceCurrency = "BDT",

                        IndividualItemsView = bundle.ProductItemBundle.ProductItemBundleJoinProductItem.Select(join =>
                        new ProductItemBundleIndividualItemView
                        {
                            ProductItemName = join.ProductItem.Name,
                            Quantity = join.ProductItemQuantity,
                            Discount = (decimal)(join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Discount) * join.ProductItemQuantity,
                            Price = (decimal)(join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Price) * join.ProductItemQuantity,
                            Vat = (decimal)(join.ProductItem.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Vat) * join.ProductItemQuantity
                        }).ToList()
                    }).ToList(),

                    PromoCode = null,
                    PriceCurrency = "BDT",
                    PromoCodeDiscount = 0,
                    TaxesAndFees = 0,
                    Message = message
                };

                foreach (var cartItem in cart.CartItems)
                {
                    cartItem.Price = (decimal)(cartItem.ProductItem.ProductItemPrice
                        .FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Price);

                    cartItem.Discount = (decimal)(cartItem.ProductItem.ProductItemPrice
                       .FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Discount);

                    cartItem.Vat = (decimal)(cartItem.ProductItem.ProductItemPrice
                       .FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Vat);
                }

                var sum = cart.CartItems.Sum(cartItem => (cartItem.Price + cartItem.Vat - cartItem.Discount) * cartItem.Quantity) +
                    cartViewModel.CartItemBundlesViewModel.Sum(bundle => (bundle.BundlePrice - bundle.BundleDiscount) * bundle.Quantity);
                cartViewModel.Subtotal = sum;
                cartViewModel.Total = sum - cartViewModel.PromoCodeDiscount + cartViewModel.TaxesAndFees;

                var priceWithoutDiscount = cart.CartItems.Sum(cartItem => (cartItem.Price + cartItem.Vat) * cartItem.Quantity) +
                    cartViewModel.CartItemBundlesViewModel.Sum(bundle =>
                    (bundle.IndividualItemsView.Sum(item => (item.Price + item.Vat) * item.Quantity)) * bundle.Quantity);

                var discount = cart.CartItems.Sum(cartItem => cartItem.Discount * cartItem.Quantity) +
                    cartViewModel.CartItemBundlesViewModel.Sum(bundle =>
                        bundle.IndividualItemsView.Sum(item => (item.Discount * item.Quantity)) * bundle.Quantity) +
                    cartViewModel.CartItemBundlesViewModel.Sum(bundle => bundle.BundleDiscount * bundle.Quantity);

                cartViewModel.DiscountTotal = discount + cartViewModel.PromoCodeDiscount;
            }
            else
            {
                var newCart = new Cart
                {
                    CreatedOn = DateTime.UtcNow
                };
                await context.Carts.AddAsync(newCart);
                await context.SaveChangesAsync();
                cartViewModel = new CartViewModel
                {
                    CartId = newCart.Id,
                    IsCreatedNow = true
                };
            }
            return cartViewModel;
        }

        public async Task<bool> DoesCartExist(int cartId)
        {
            return await context.Carts.AsNoTracking().Where(c => c.Id == cartId).AnyAsync();
        }

        private async Task<bool> DoesProductItemExistInCart(int cartId, int productItemId)
        {
            bool exist = await context.CartItems.AsNoTracking()
                .AnyAsync(ci => ci.CartId == cartId && ci.ProductItemId == productItemId);

            return exist;
        }
        private async Task<bool> DoesProductItemBundleExistInCart(int cartId, int productItemBundleId)
        {
            bool exist = await context.CartProductItemBundles.AsNoTracking()
                .AnyAsync(cpb => cpb.CartId == cartId && cpb.ProductItemBundleId == productItemBundleId);

            return exist;
        }

        public async Task<AddCartItemBundleViewModel> AddProductItemBundletoCart(int cartId, string userId,
            int productItemBundleId, int quantity)
        {
            AddCartItemBundleViewModel cartItemBundleViewModel = new AddCartItemBundleViewModel();
            var cart = await context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.ProductItem)
                        .ThenInclude(pi => pi.ProductStockCount)
                .Include(c => c.CartProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                        .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                            .ThenInclude(join => join.ProductItem)
                                .ThenInclude(pi => pi.ProductStockCount)
                 .Where(c => c.Id == cartId).FirstOrDefaultAsync();

            //No cart found
            if (cart == null)
            {
                cart = await CreateCart(userId);
                cartItemBundleViewModel.IsCartCreatedWhenAdded = true;
                cartItemBundleViewModel.CreatedCartId = cart.Id;
            }

            var productItemBundle = await context.ProductItemBundles
                .Include(bundle => bundle.ProductItemBundleJoinProductItem)
                    .ThenInclude(join => join.ProductItem)
                        .ThenInclude(pi => pi.ProductStockCount)
                .FirstOrDefaultAsync(bundle => bundle.Id == productItemBundleId);

            var minStock = productItemBundle.ProductItemBundleJoinProductItem
                .Min(join => join.ProductItem.ProductStockCount.Count / join.ProductItemQuantity);

            if (cart != null && productItemBundle != null && quantity > 0 && minStock > 0)
            {
                if (!await DoesProductItemBundleExistInCart(cart.Id, productItemBundle.Id))
                {
                    bool stockAvailable = true;
                    bool minStockAvailable = true;
                    foreach (var join in productItemBundle.ProductItemBundleJoinProductItem)
                    {
                        int countInCartItems = cart.CartItems.Count(ci => ci.ProductItemId == join.ProductItemId);
                        int countInOtherBundles = cart.CartProductItemBundles
                            .Where(bundle => bundle.ProductItemBundleId != productItemBundle.Id)
                            .Sum(bundle => bundle.Quantity * (bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                            .FirstOrDefault(join2 => join2.ProductItemId == join.ProductItemId)
                            ?.ProductItemQuantity ?? 0));

                        if (quantity * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                            join.ProductItem.ProductStockCount.Count)
                        {
                            stockAvailable = false;
                        }

                        if (minStock * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                           join.ProductItem.ProductStockCount.Count)
                        {
                            minStockAvailable = false;
                        }
                    }

                    if (stockAvailable || minStockAvailable)
                    {
                        var cartJoincartItemBundle = new CartProductItemBundle
                        {
                            CartId = cart.Id,
                            ProductItemBundleId = productItemBundle.Id,
                            Quantity = stockAvailable ? quantity : minStock
                        };

                        await context.CartProductItemBundles.AddAsync(cartJoincartItemBundle);
                    }
                    else
                    {
                        return null;
                    }

                    try
                    {
                        await context.SaveChangesAsync();
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

                    var cartJoinProductItemBundle = await context.CartProductItemBundles
                        .FirstAsync(bundle => bundle.ProductItemBundleId == productItemBundleId && bundle.CartId == cart.Id);

                    quantity += cartJoinProductItemBundle.Quantity;
                    bool stockAvailable = true;
                    bool minStockAvailable = true;
                    foreach (var join in productItemBundle.ProductItemBundleJoinProductItem)
                    {
                        int countInCartItems = cart.CartItems.Count(ci => ci.ProductItemId == join.ProductItemId);
                        int countInOtherBundles = cart.CartProductItemBundles
                            .Where(bundle => bundle.ProductItemBundleId != productItemBundle.Id)
                            .Sum(bundle => bundle.Quantity * (bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                            .FirstOrDefault(join2 => join2.ProductItemId == join.ProductItemId)
                            ?.ProductItemQuantity ?? 0));

                        if (quantity * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                            join.ProductItem.ProductStockCount.Count)
                        {
                            stockAvailable = false;
                        }

                        if (minStock * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                           join.ProductItem.ProductStockCount.Count)
                        {
                            minStockAvailable = false;
                        }
                    }

                    if (stockAvailable)
                    {
                        cartJoinProductItemBundle.Quantity = quantity;
                    }
                    else if (minStockAvailable)
                    {
                        cartJoinProductItemBundle.Quantity = minStock;
                        cartItemBundleViewModel.Message = $"Sorry, we have a shortage of one or more items, the available quantity is {minStock} and added to your cart.";
                        cartItemBundleViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                    }

                    if (cartJoinProductItemBundle.Quantity > ProductConfig.MaxItemAllowedInCart)
                    {
                        cartJoinProductItemBundle.Quantity = ProductConfig.MaxItemAllowedInCart;
                        cartItemBundleViewModel.Message = $"We are glad that you like to buy a lot of stuffs but the " +
                            $"possible maximum quantity of a product in cart is {ProductConfig.MaxItemAllowedInCart}, that" +
                            $" is added to your cart.";
                        cartItemBundleViewModel.MessageClass = "alert alert-info alert-dismissible fade show";
                    }
                    try
                    {
                        await context.SaveChangesAsync();
                        cartItemBundleViewModel.ProductItemBundle = productItemBundle;
                        return cartItemBundleViewModel;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public async Task<bool> DeleteProductItemBundleFromCart(int cartId, int productItemBundleId)
        {
            var cart = await context.Carts.FindAsync(cartId);
            var bundle = await context.ProductItemBundles.FindAsync(productItemBundleId);
            if (cart != null && bundle != null)
            {
                context.CartProductItemBundles.Remove(await context.CartProductItemBundles
                    .Where(j => j.CartId == cartId && j.ProductItemBundleId == productItemBundleId).FirstOrDefaultAsync());
                try
                {
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<CartProductItemBundle> UpdateProductItemBundleQuantity(int cartId, int productItemBundleId, int quantity)
        {
            var cart = await context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.ProductItem)
                        .ThenInclude(pi => pi.ProductStockCount)
                .Include(c => c.CartProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                        .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                            .ThenInclude(join => join.ProductItem)
                                .ThenInclude(pi => pi.ProductStockCount)
                 .Where(c => c.Id == cartId).FirstOrDefaultAsync();

            if (cart != null && quantity > 0)
            {
                try
                {
                    var cartProductItemBundle = cart.CartProductItemBundles
                        .First(bundle => bundle.ProductItemBundleId == productItemBundleId);

                    var minStock = cartProductItemBundle.ProductItemBundle.ProductItemBundleJoinProductItem
                .Min(join => join.ProductItem.ProductStockCount.Count / join.ProductItemQuantity);

                    bool stockAvailable = true;
                    bool minStockAvailable = true;
                    foreach (var join in cartProductItemBundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                    {
                        int countInCartItems = cart.CartItems.Count(ci => ci.ProductItemId == join.ProductItemId);
                        int countInOtherBundles = cart.CartProductItemBundles
                            .Where(bundle => bundle.ProductItemBundleId != cartProductItemBundle.ProductItemBundleId)
                            .Sum(bundle => bundle.Quantity * (bundle.ProductItemBundle.ProductItemBundleJoinProductItem
                            .FirstOrDefault(join2 => join2.ProductItemId == join.ProductItemId)
                            ?.ProductItemQuantity ?? 0));

                        if (quantity * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                            join.ProductItem.ProductStockCount.Count)
                        {
                            stockAvailable = false;
                        }

                        if (minStock * join.ProductItemQuantity + countInCartItems + countInOtherBundles >
                           join.ProductItem.ProductStockCount.Count)
                        {
                            minStockAvailable = false;
                        }
                    }

                    if (stockAvailable)
                    {
                        cartProductItemBundle.Quantity = quantity;
                    }
                    else if (minStockAvailable)
                    {
                        cartProductItemBundle.Quantity = minStock;
                    }

                    await context.SaveChangesAsync();

                    return cartProductItemBundle;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<int> GetCartItemCount(int cartId)
        {

            var itemsCount = await context.CartItems
                 .Where(cartItem => cartItem.CartId == cartId).CountAsync();
            var bundleCount = await context.CartProductItemBundles.Where(bundle => bundle.CartId == cartId).CountAsync();
            return itemsCount + bundleCount;

        }

        public async Task<bool> DeleteCart(int cartId)
        {
            try
            {
                var cart = await context.Carts.FindAsync(cartId);
                context.Carts.Remove(cart);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> GetUserCartId(string userId)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = await CreateCart(userId);
            }
            return cart.Id;
        }

        public async Task<Cart> RemoveOutOfStockItems(int cartId)
        {
            try
            {
                var cart = await context.Carts
                    .Include(c => c.CartItems)
                        .ThenInclude(ci => ci.ProductItem)
                            .ThenInclude(pi => pi.ProductStockCount)
                    .Include(c => c.CartProductItemBundles)
                        .ThenInclude(bundle => bundle.ProductItemBundle)
                            .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                                .ThenInclude(join => join.ProductItem)
                                    .ThenInclude(pi => pi.ProductStockCount)
                    .Where(c => c.Id == cartId).FirstOrDefaultAsync();

                var outOfStockProductItems = PopulateOutOfStockCartProductItems(cart);

                //Remove out of stock items from cart items
                if (outOfStockProductItems != null && outOfStockProductItems.Any())
                {
                    for (int i = cart.CartItems.Count - 1; i >= 0; i--)
                    {
                        var cartItem = cart.CartItems.ElementAt(i);
                        var outOfStockProductItem = outOfStockProductItems.FirstOrDefault(t => t.ProductItem.Id == cartItem.ProductItemId);
                        if (outOfStockProductItem != null)
                        {
                            if (outOfStockProductItem.Quantity >= cartItem.Quantity)
                            {
                                outOfStockProductItem.Quantity -= cartItem.Quantity;
                                cart.CartItems.Remove(cartItem);

                                if (outOfStockProductItem.Quantity == 0)
                                {
                                    outOfStockProductItems.Remove(outOfStockProductItem);
                                }
                            }
                            else
                            {
                                cartItem.Quantity -= outOfStockProductItem.Quantity;
                                outOfStockProductItems.Remove(outOfStockProductItem);
                            }
                        }
                    }
                }

                //Remove out of stock items from cart item bundles
                if (outOfStockProductItems != null && outOfStockProductItems.Any())
                {
                    for (int i = cart.CartProductItemBundles.Count - 1; i >= 0; i--)
                    {
                        var bundle = cart.CartProductItemBundles.ElementAt(i);
                        bool shouldDelete = false;
                        foreach (var bundleItem in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                        {
                            var outOfStockProductItem = outOfStockProductItems
                                .FirstOrDefault(t => t.ProductItem.Id == bundleItem.ProductItemId);
                            if (outOfStockProductItem != null)
                            {
                                var bundleQty = bundle.Quantity;
                                while (bundleQty > 0)
                                {
                                    if (bundleQty * bundleItem.ProductItemQuantity >= outOfStockProductItem.Quantity)
                                    {
                                        outOfStockProductItem.Quantity -= bundleQty * bundleItem.ProductItemQuantity;
                                        bundleQty--;
                                        if (outOfStockProductItem.Quantity <= 0)
                                        {
                                            outOfStockProductItems.Remove(outOfStockProductItem);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                bundle.Quantity = bundleQty;
                                if (bundle.Quantity <= 0)
                                {
                                    shouldDelete = true;
                                    break;
                                }
                            }
                        }

                        if (shouldDelete)
                        {
                            cart.CartProductItemBundles.Remove(bundle);
                        }

                    }
                }

                await context.SaveChangesAsync();
                return cart;
            }
            catch
            {
                return null;
            }
        }

        private async Task<Cart> RemoveOutOfStockItemsFromGivenCart(Cart cart)
        {
            try
            {
                var outOfStockProductItems = PopulateOutOfStockCartProductItems(cart);

                //Remove out of stock items from cart items
                if (outOfStockProductItems != null && outOfStockProductItems.Any())
                {
                    for (int i = cart.CartItems.Count - 1; i >= 0; i--)
                    {
                        var cartItem = cart.CartItems.ElementAt(i);
                        var outOfStockProductItem = outOfStockProductItems.FirstOrDefault(t => t.ProductItem.Id == cartItem.ProductItemId);
                        if (outOfStockProductItem != null)
                        {
                            if (outOfStockProductItem.Quantity >= cartItem.Quantity)
                            {
                                outOfStockProductItem.Quantity -= cartItem.Quantity;
                                cart.CartItems.Remove(cartItem);

                                if (outOfStockProductItem.Quantity == 0)
                                {
                                    outOfStockProductItems.Remove(outOfStockProductItem);
                                }
                            }
                            else
                            {
                                cartItem.Quantity -= outOfStockProductItem.Quantity;
                                outOfStockProductItems.Remove(outOfStockProductItem);
                            }
                        }
                    }
                }

                //Remove out of stock items from cart item bundles
                if (outOfStockProductItems != null && outOfStockProductItems.Any())
                {
                    for (int i = cart.CartProductItemBundles.Count - 1; i >= 0; i--)
                    {
                        var bundle = cart.CartProductItemBundles.ElementAt(i);
                        bool shouldDelete = false;
                        foreach (var bundleItem in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                        {
                            var outOfStockProductItem = outOfStockProductItems
                                .FirstOrDefault(t => t.ProductItem.Id == bundleItem.ProductItemId);
                            if (outOfStockProductItem != null)
                            {
                                var bundleQty = bundle.Quantity;
                                while (bundleQty > 0)
                                {
                                    if (bundleQty * bundleItem.ProductItemQuantity >= outOfStockProductItem.Quantity)
                                    {
                                        outOfStockProductItem.Quantity -= bundleQty * bundleItem.ProductItemQuantity;
                                        bundleQty--;
                                        if (outOfStockProductItem.Quantity <= 0)
                                        {
                                            outOfStockProductItems.Remove(outOfStockProductItem);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                bundle.Quantity = bundleQty;
                                if (bundle.Quantity <= 0)
                                {
                                    shouldDelete = true;
                                    break;
                                }
                            }
                        }

                        if (shouldDelete)
                        {
                            cart.CartProductItemBundles.Remove(bundle);
                        }

                    }
                }

                await context.SaveChangesAsync();
                return cart;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<ProductItemAndQty>> GetOutOfStockCartProductItems(int cartId)
        {

            try
            {
                var cart = await context.Carts.AsNoTracking()
                    .Include(c => c.CartItems)
                        .ThenInclude(ci => ci.ProductItem)
                            .ThenInclude(pi => pi.ProductStockCount)
                    .Include(c => c.CartProductItemBundles)
                        .ThenInclude(bundle => bundle.ProductItemBundle)
                            .ThenInclude(pb => pb.ProductItemBundleJoinProductItem)
                                .ThenInclude(join => join.ProductItem)
                                    .ThenInclude(pi => pi.ProductStockCount)
                    .Where(c => c.Id == cartId).FirstOrDefaultAsync();

                return PopulateOutOfStockCartProductItems(cart);
            }
            catch
            {
                return null;
            }
        }

        private IList<ProductItemAndQty> PopulateOutOfStockCartProductItems(Cart cart)
        {
            //ProductItem and quantity
            var outOfStockItems = new List<ProductItemAndQty>();

            var productItemIdQuantity = new Dictionary<int, int>(); //productItemId, quantity
            var productItems = new Dictionary<int, ProductItem>();

            try
            {
                //Check individual items
                foreach (var cartItem in cart.CartItems)
                {
                    if (productItemIdQuantity.ContainsKey(cartItem.ProductItem.Id))
                    {
                        var qty = productItemIdQuantity[cartItem.ProductItem.Id];
                        qty += cartItem.Quantity;
                        productItemIdQuantity[cartItem.ProductItem.Id] = qty;
                    }
                    else
                    {
                        productItems.Add(cartItem.ProductItem.Id, cartItem.ProductItem);
                        productItemIdQuantity.Add(cartItem.ProductItem.Id, cartItem.Quantity);
                    }
                }

                //Check bundle items
                foreach (var bundle in cart.CartProductItemBundles)
                {
                    foreach (var bundleItem in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                    {
                        var qty = bundle.Quantity * bundleItem.ProductItemQuantity;

                        if (productItemIdQuantity.ContainsKey(bundleItem.ProductItem.Id))
                        {
                            qty += productItemIdQuantity[bundleItem.ProductItem.Id];
                            productItemIdQuantity[bundleItem.ProductItem.Id] = qty;
                        }
                        else
                        {
                            productItems.Add(bundleItem.ProductItem.Id, bundleItem.ProductItem);
                            productItemIdQuantity.Add(bundleItem.ProductItem.Id, qty);
                        }
                    }
                }

                //Now we have flattened the quantity of all productItem of the cart in 'productItemIdQuantity'.
                //Now filter the out of stock items
                foreach (var itemQty in productItemIdQuantity)
                {
                    var productItem = productItems[itemQty.Key];

                    //If required quantity is greater than stock count, add to result.
                    if (itemQty.Value > productItem.ProductStockCount.Count)
                    {
                        var missingQty = itemQty.Value - productItem.ProductStockCount.Count;
                        var item = new ProductItemAndQty
                        {
                            ProductItem = productItem,
                            Quantity = missingQty
                        };
                        outOfStockItems.Add(item);
                    }
                }

                return outOfStockItems;
            }
            catch
            {
                return null;
            }
        }
    }
}
