using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;

namespace Digital_Services_BD.Services;

public static class CartStockAllocator
{
    // Keep standalone lines first, then bundles in stable order. Never reserve inventory here:
    // checkout revalidates stock and fulfillment performs the transactional allocation.
    public static void Normalize(Cart cart)
    {
        var remaining = new Dictionary<int, int>();
        int Available(ProductItem product)
        {
            if (!remaining.TryGetValue(product.Id, out var count))
                remaining[product.Id] = count = product.IsActive ? Math.Max(0, product.ProductStockCount?.Count ?? 0) : 0;
            return count;
        }
        foreach (var item in cart.CartItems.OrderBy(i => i.Id).ToArray())
        {
            item.Quantity = Math.Clamp(item.Quantity, 0, Math.Min(Available(item.ProductItem), ProductConfig.MaxItemAllowedInCart));
            remaining[item.ProductItemId] -= item.Quantity;
            if (item.Quantity == 0) cart.CartItems.Remove(item);
        }
        foreach (var line in cart.CartProductItemBundles.OrderBy(b => b.ProductItemBundleId).ToArray())
        {
            var items = line.ProductItemBundle.ProductItemBundleJoinProductItem;
            var limit = line.ProductItemBundle.IsActiveNow && items.Count > 0 && items.All(i => i.ProductItemQuantity > 0)
                ? items.Min(i => Available(i.ProductItem) / i.ProductItemQuantity) : 0;
            line.Quantity = Math.Clamp(line.Quantity, 0, Math.Min(limit, ProductConfig.MaxItemAllowedInCart));
            foreach (var item in items)
                remaining[item.ProductItemId] = Available(item.ProductItem) - line.Quantity * item.ProductItemQuantity;
            if (line.Quantity == 0) cart.CartProductItemBundles.Remove(line);
        }
    }
}
