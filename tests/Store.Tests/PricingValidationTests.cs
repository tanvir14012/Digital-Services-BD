using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Xunit;

namespace Store.Tests;

public class PricingValidationTests
{
    [Fact]
    public void InactiveProductsCannotBePricedForCheckout()
    {
        Assert.Null(CartPricing.GetPrice(new ProductItem { IsActive = false,
            ProductItemPrice = [new() { PriceCurrency = "BDT", Price = 100 }] }));
    }

    [Fact]
    public void BundleDiscountCannotMakeTotalNegative()
    {
        var product = new ProductItem { IsActive = true, ProductItemPrice = [new() { PriceCurrency = "BDT", Price = 100 }] };
        Assert.False(CartPricing.IsValidBundle(new ProductItemBundle { BundleDiscount = 201,
            ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemQuantity = 2 }] }));
    }

    [Fact]
    public void EmptyBundlesCannotProceedToCheckout() => Assert.False(CartPricing.IsValidBundle(new ProductItemBundle()));
}
