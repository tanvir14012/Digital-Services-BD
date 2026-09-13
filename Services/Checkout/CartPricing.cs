using Digital_Services_BD.Constants;
using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;

namespace Digital_Services_BD.Services;

public static class CartPricing
{
    public static ProductItemPrice? GetPrice(ProductItem product) => !product.IsActive ? null : product.ProductItemPrice
        .FirstOrDefault(price => price.PriceCurrency == StoreDefaults.Currency && price.Price >= 0
            && price.Discount >= 0 && price.Discount <= price.Price && price.Vat >= 0);

    public static bool IsValidBundle(ProductItemBundle bundle)
    {
        var items = bundle.ProductItemBundleJoinProductItem;
        return bundle.IsActiveNow && bundle.BundleDiscount >= 0 && items.Count > 0
            && items.All(item => item.ProductItemQuantity > 0 && GetPrice(item.ProductItem) != null)
            && items.Sum(item => (GetPrice(item.ProductItem)!.Price - GetPrice(item.ProductItem)!.Discount
                + GetPrice(item.ProductItem)!.Vat) * item.ProductItemQuantity) >= bundle.BundleDiscount;
    }

    public static CartItemBundleViewModel CreateBundle(CartProductItemBundle line)
    {
        var items = line.ProductItemBundle.ProductItemBundleJoinProductItem.Select(item =>
        {
            var price = GetPrice(item.ProductItem) ?? throw new InvalidOperationException("Product has no valid store price.");
            return new ProductItemBundleIndividualItemView { ProductItemName = item.ProductItem.Name,
                Quantity = item.ProductItemQuantity, Price = price.Price * item.ProductItemQuantity,
                Discount = price.Discount * item.ProductItemQuantity, Vat = price.Vat * item.ProductItemQuantity };
        }).ToList();
        return new CartItemBundleViewModel { ProductItemBundleId = line.ProductItemBundleId,
            Name = line.ProductItemBundle.Name, Quantity = line.Quantity, PriceCurrency = StoreDefaults.Currency,
            BundlePrice = items.Sum(item => item.Price + item.Vat),
            BundleDiscount = items.Sum(item => item.Discount) + line.ProductItemBundle.BundleDiscount,
            IndividualItemsView = items };
    }
}
