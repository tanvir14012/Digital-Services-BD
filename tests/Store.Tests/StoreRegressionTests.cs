using Digital_Services_BD.Extensions;
using Digital_Services_BD.Infrastructure.Security;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Store.Tests;

public class StoreRegressionTests
{
    private static AppDbContext Database() => new(new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

    [Fact]
    public async Task GuestsGetSeparateCarts()
    {
        using var db = Database();
        var carts = new CartOps(db);
        var first = await carts.CreateCart(null!);
        var second = await carts.CreateCart(null!);
        Assert.NotEqual(first.Id, second.Id);
    }

    [Fact]
    public async Task CannotDeleteAnItemFromAnotherCart()
    {
        using var db = Database();
        db.CartItems.Add(new CartItem { Id = 10, CartId = 2, Quantity = 1 });
        await db.SaveChangesAsync();
        Assert.Null(await new CartOps(db).DeleteCartItemFromCart(1, 10));
        Assert.True(await db.CartItems.AnyAsync(item => item.Id == 10));
    }

    [Fact]
    public async Task EmptyCartPreservesCartAndOrderReference()
    {
        using var db = Database();
        db.Carts.Add(new Cart { Id = 1 });
        db.CartItems.Add(new CartItem { CartId = 1, Quantity = 1 });
        await db.SaveChangesAsync();
        Assert.True(await new CartOps(db).EmptyCart(1));
        Assert.True(await db.Carts.AnyAsync(c => c.Id == 1));
        Assert.Empty(db.CartItems);
    }

    [Fact]
    public async Task SearchFiltersBeforeCountingAndPagingAndUsesDiscountedPrice()
    {
        using var db = Database();
        for (var i = 1; i <= 40; i++)
            db.ProductItems.Add(new ProductItem { Id = i, Name = $"Product {i:00}", Overview = "Test", ImageUrl = "test.png", IsActive = true,
                ProductItemPrice = [new() { PriceCurrency = "BDT", Price = i * 10, Discount = i == 40 ? 395 : 0 }] });
        await db.SaveChangesAsync();
        var result = await new SearchService(db).SearchProducts(new SearchView { Term = "product", SortBy = "p_l_h", PriceRange = "0to100", PageNo = 1 });
        Assert.Equal(11, result.TotalItems);
        Assert.Equal(40, result.Products.First().Id);
        Assert.All(result.Products, p => Assert.InRange(p.ProductItemPrice[0].Price - p.ProductItemPrice[0].Discount, 0, 100));
    }

    [Theory]
    [InlineData("1")]
    [InlineData("214748364888888888888888")]
    [InlineData("invalid")]
    public void ForgedCartCookiesAreRejected(string value)
    {
        var http = new DefaultHttpContext();
        http.Request.Headers.Cookie = $"CartId={value}";
        Assert.Null(new CartCookie(new EphemeralDataProtectionProvider()).Read(http.Request));
    }

    [Fact]
    public void CartCookieRoundTripsAndIsHttpOnlyAndSecure()
    {
        var cookie = new CartCookie(new EphemeralDataProtectionProvider());
        var http = new DefaultHttpContext();
        cookie.Write(http.Response, 42);
        var header = http.Response.Headers.SetCookie.ToString();
        Assert.Contains("httponly", header);
        Assert.Contains("secure", header);
        http.Request.Headers.Cookie = header.Split(';')[0];
        Assert.Equal(42, cookie.Read(http.Request));
    }

    [Fact]
    public void CatalogPaginationDoesNotReturnWholeCatalogForHugePage()
    {
        Assert.Empty(Enumerable.Range(1, 30).Page(int.MaxValue, 10));
        Assert.Equal(Enumerable.Range(1, 10), Enumerable.Range(1, 30).Page(-1, 10));
    }
}
