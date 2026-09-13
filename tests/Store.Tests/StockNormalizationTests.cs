using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Xunit;

namespace Store.Tests;

public class StockNormalizationTests
{
    [Fact]
    public void BundleReductionAccountsForUnitsPerBundleAndStandaloneQuantities()
    {
        var product = new ProductItem { Id = 1, IsActive = true, ProductStockCount = new() { Count = 5 } };
        var line = new CartProductItemBundle { ProductItemBundleId = 1, Quantity = 4,
            ProductItemBundle = new() { ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemId = 1, ProductItemQuantity = 2 }] } };
        var cart = new Cart { CartItems = [new() { ProductItemId = 1, ProductItem = product, Quantity = 3 }], CartProductItemBundles = [line] };
        CartStockAllocator.Normalize(cart);
        Assert.Equal(1, line.Quantity);
        Assert.Equal(3, cart.CartItems.Single().Quantity);
    }

    [Fact]
    public void MultipleBundlesShareAvailableStockWithoutNegativeQuantities()
    {
        var product = new ProductItem { Id = 1, IsActive = true, ProductStockCount = new() { Count = 3 } };
        CartProductItemBundle Line(int id) => new() { ProductItemBundleId = id, Quantity = 2,
            ProductItemBundle = new() { ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemId = 1, ProductItemQuantity = 2 }] } };
        var cart = new Cart { CartProductItemBundles = [Line(2), Line(1)] };
        CartStockAllocator.Normalize(cart);
        Assert.Equal(1, cart.CartProductItemBundles.Single().ProductItemBundleId);
        Assert.Equal(1, cart.CartProductItemBundles.Single().Quantity);
    }

    [Fact]
    public void EmptyAndInvalidBundlesAreRemovedWithoutDivisionByZero()
    {
        var product = new ProductItem { Id = 1, IsActive = true, ProductStockCount = new() { Count = 3 } };
        var cart = new Cart { CartProductItemBundles = [new() { Quantity = 2, ProductItemBundle = new() },
            new() { Quantity = 2, ProductItemBundle = new() { ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemId = 1, ProductItemQuantity = 0 }] } }] };
        CartStockAllocator.Normalize(cart);
        Assert.Empty(cart.CartProductItemBundles);
    }
}
