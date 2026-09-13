using Digital_Services_BD.Extensions;
using System.Globalization;
using Digital_Services_BD.Constants;
using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using Microsoft.EntityFrameworkCore;
using static Digital_Services_BD.ViewModels.ProductConfig;

namespace Digital_Services_BD.Services;

public class SearchService(AppDbContext context) : ISearchService
{
    public async Task<SearchView> SearchProducts(SearchView model)
    {
        var words = (model.Term ?? string.Empty).Trim().ToLowerInvariant()
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Distinct().Take(20).ToArray();
        var query = context.ProductItems.AsNoTracking()
            .Where(item => item.IsActive).WhereContainsAny(item => item.Name, words);
        var range = model.PriceRange?.Split("to", StringSplitOptions.None);
        if (range is { Length: 2 } && decimal.TryParse(range[0], NumberStyles.None, CultureInfo.InvariantCulture, out var min)
            && decimal.TryParse(range[1], NumberStyles.None, CultureInfo.InvariantCulture, out var max) && min <= max)
        {
            query = query.Where(item => item.ProductItemPrice.Any(p => p.PriceCurrency == StoreDefaults.Currency
                && p.Price - p.Discount >= min && p.Price - p.Discount <= max));
        }
        model.TotalItems = await query.CountAsync();
        model.PageNo = Math.Clamp(model.PageNo, 1, Math.Max(1, (int)Math.Ceiling((double)model.TotalItems / NoOfProductItemPerPage)));
        var ordered = model.SortBy switch
        {
            "p_l_h" => query.OrderBy(item => item.ProductItemPrice.Where(p => p.PriceCurrency == StoreDefaults.Currency)
                .Select(p => (decimal?)(p.Price - p.Discount)).FirstOrDefault()),
            "p_h_l" => query.OrderByDescending(item => item.ProductItemPrice.Where(p => p.PriceCurrency == StoreDefaults.Currency)
                .Select(p => (decimal?)(p.Price - p.Discount)).FirstOrDefault()),
            _ => query.OrderBy(item => item.Name)
        };
        model.Products = await ordered.ThenBy(item => item.Id).Skip((model.PageNo - 1) * NoOfProductItemPerPage)
            .Take(NoOfProductItemPerPage).Include(item => item.ProductItemPrice).ToListAsync();
        return model;
    }
}
