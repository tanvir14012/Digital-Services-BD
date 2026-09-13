using Digital_Services_BD.Extensions;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Store.Tests;

public class CommerceRegressionTests
{
    private static AppDbContext Database() => new(new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options);

    private static ProductItem Product() => new() { Id = 1, Name = "Gift card", Overview = "Test", ImageUrl = "test.png", IsActive = true,
        ProductStockCount = new() { Count = 100 }, ProductItemPrice = [new() { PriceCurrency = "BDT", Price = 100, Discount = 10, Vat = 5 }] };

    [Fact]
    public async Task BundleDiscountAndQuantityAreAppliedExactlyOnce()
    {
        using var db = Database();
        var product = Product();
        var bundle = new ProductItemBundle { Name = "Pair", BundleDiscount = 5,
            ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemQuantity = 2 }] };
        db.Carts.Add(new Cart { Id = 1, CartProductItemBundles = [new() { ProductItemBundle = bundle, Quantity = 3 }] });
        await db.SaveChangesAsync();
        var cart = await new CartOps(db).GetCart(1);
        Assert.Equal(75, cart.DiscountTotal); // (2 * 10 + 5) * 3
        Assert.Equal(555, cart.Total); // (2 * (100 + 5) - 25) * 3
    }

    [Fact]
    public async Task FirstSignInAdoptsGuestCartAndRepeatMergeDoesNotDoubleQuantities()
    {
        using var db = Database();
        db.Carts.Add(new Cart { Id = 1, CartItems = [new() { ProductItem = Product(), Quantity = 2 }] });
        await db.SaveChangesAsync();
        var carts = new CartOps(db);
        Assert.Equal("customer", (await carts.MergeCarts(1, "customer")).UserId);
        Assert.Equal(2, (await carts.MergeCarts(1, "customer")).CartItems.Single().Quantity);
    }

    [Fact]
    public async Task MergeCannotClaimAnotherCustomersCart()
    {
        using var db = Database();
        db.Carts.Add(new Cart { Id = 1, UserId = "owner" });
        await db.SaveChangesAsync();
        var cart = await new CartOps(db).MergeCarts(1, "other");
        Assert.NotEqual(1, cart.Id);
        Assert.Equal("owner", (await db.Carts.FindAsync(1))!.UserId);
    }

    [Fact]
    public void SearchPredicateTranslatesToSqlServer()
    {
        using var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=unused;Database=unused;Integrated Security=true").Options);
        var sql = db.ProductItems.WhereContainsAny(p => p.Name, ["gift", "card"]).OrderBy(p => p.Id).Skip(10).Take(10).ToQueryString();
        Assert.Contains(" OR ", sql);
        Assert.Contains("OFFSET", sql);
    }

    [Fact]
    public async Task StockIsNotAllocatedTwiceAcrossStandaloneAndBundleLines()
    {
        using var db = Database();
        var product = Product();
        var bundle = new ProductItemBundle { Name = "Bundle", ProductItemBundleJoinProductItem = [new() { ProductItem = product, ProductItemQuantity = 1 }] };
        var order = new Order { PriceCurrency = "BDT", ConfirmEmail = "test@example.invalid", Status = OrderStatus.PROCESSING,
            Transaction = new PaymentTransaction { SurjoPayCode = 1000, SurjoPayOrderId = "test", Status = "Paid" },
            OrderItems = [new() { Name = product.Name, PriceCurrency = "BDT", ProductItem = product, Quantity = 1 }],
            OrderProductItemBundles = [new() { ProductItemBundle = bundle, Quantity = 1, PriceCurrency = "BDT" }] };
        db.Orders.Add(order);
        db.ProductStocks.Add(new ProductStock { MainCode = "TEST-ONLY", ProductItem = product, Status = ProductStockStatus.ACTIVE });
        await db.SaveChangesAsync();
        var result = await new OrderOps(db).PickDeliverables(order.Id);
        Assert.NotNull(result);
        Assert.Single(result.Order.Deliverable.DeliverableItems);
        Assert.Empty(result.Order.Deliverable.DeliverableBundles.Single().DeliverableBundleItems);
        Assert.Equal(1, result.UnpickedProducts.Single().Quantity);
    }
}
