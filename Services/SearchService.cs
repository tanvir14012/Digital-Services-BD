using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;

using Microsoft.EntityFrameworkCore;

using static Digital_Services_BD.ViewModels.ProductConfig;

namespace Digital_Services_BD.Services
{
    public class SearchService : ISearchService
    {
        private readonly AppDbContext context;

        public SearchService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<SearchView> SearchProducts(SearchView model)
        {
            var words = model.Term.ToLower().Trim().Split().ToList();
            words = words.Where(w => !string.IsNullOrEmpty(w)).ToList();

            var products = await context.ProductItems
                .AsNoTracking()
                .Include(p => p.ProductItemPrice)
                .ToListAsync();

            products = products.Where(item => words.Any(word => item.Name.ToLower().Contains(word))).ToList();

            model.TotalItems = products.Count();

            products = products.Skip((model.PageNo - 1) * NoOfProductItemPerPage)
                                .Take(NoOfProductItemPerPage)
                                .OrderBy(item => item.Name)
                                .ToList();

            if (model.PriceRange != null && Regex.IsMatch(model.PriceRange, @"^\d+to\d+$"))
            {
                decimal minPrice = Convert.ToDecimal(model.PriceRange.Split("to")[0]);
                decimal maxPrice = Convert.ToDecimal(model.PriceRange.Split("to")[1]);

                var skipProducts = new List<ProductItem>();
                foreach (var product in products)
                {
                    var priceObject = product.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT");
                    if (priceObject != null)
                    {
                        var price = priceObject.Price - priceObject.Discount;
                        if (!(price >= minPrice && price <= maxPrice))
                        {
                            skipProducts.Add(product);
                        }
                    }
                }
                products.RemoveAll(p => skipProducts.Contains(p));
            }

            if (model.SortBy != null)
            {
                switch (model.SortBy)
                {
                    case "p_l_h":
                        products = products.OrderBy(p => p.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Price).ToList();
                        break;
                    case "p_h_l":
                        products = products.OrderByDescending(p => p.ProductItemPrice.FirstOrDefault(pr => pr.PriceCurrency == "BDT")?.Price).ToList();
                        break;
                    default:
                        break;
                }
            }

            model.Products = products;
            return model;
        }
    }
}
