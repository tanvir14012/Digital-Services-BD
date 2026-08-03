using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{id}")]
    public class CategoryController : Controller
    {
        private readonly IProductGroupOps productGroupOps;
        private readonly IProductCategoryOps productCategoryOps;

        public CategoryController(IProductGroupOps productGroupOps, IProductCategoryOps productCategoryOps)
        {
            this.productGroupOps = productGroupOps;
            this.productCategoryOps = productCategoryOps;
        }
        public IActionResult Index([FromRoute] int id, [FromQuery] int pageNo = 1,
            [FromQuery] string sortBy = null, [FromQuery] string priceRange = null)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    var filteredCategories = productGroupOps.FilterCategories(productGroup.Id, pageNo - 1, sortBy, priceRange);
                    ViewBag.Id = productGroup.Id;
                    ViewBag.ProductGroupName = productGroup.Name;
                    ViewBag.TotalCategory = filteredCategories.TotalCategories;
                    ViewBag.PageNo = pageNo;
                    ViewBag.SortBy = sortBy ?? "m_p";
                    if (priceRange != null && Regex.IsMatch(priceRange, @"^\d+to\d+$") && priceRange.Length <= 10)
                    {
                        ViewBag.PriceMin = Convert.ToInt32(priceRange.Split("to")[0]);
                        ViewBag.PriceMax = Convert.ToInt32(priceRange.Split("to")[1]);
                    }
                    else
                    {
                        ViewBag.PriceMin = ProductConfig.MinPrice;
                        ViewBag.PriceMax = ProductConfig.MaxPrice;
                    }
                    ViewBag.ProductGroups = productGroupOps.GetAllProductGroups().ToList();

                    var categoryMinMaxPrice = new Dictionary<int, Tuple<decimal, decimal>>(); // category id, min price, max price
                    filteredCategories.CategoriesUnderFilter.ToList().ForEach(category =>
                    {
                        categoryMinMaxPrice.Add(category.Id, new Tuple<decimal, decimal>(
                            productCategoryOps.GetMinProductPriceByCatgId(category.Id),
                            productCategoryOps.GetMaxProductPriceByCatgId(category.Id)));
                    });
                    ViewBag.CategoryMinMaxPrice = categoryMinMaxPrice;

                    return View(filteredCategories.CategoriesUnderFilter);
                }
            }
            ViewBag.Heading = "Page Not Found";
            ViewBag.Message = "This is not the page you are looking for. Please check spelling and try again.";
            ViewBag.Action = "Index";
            ViewBag.Controller = "Category";
            ViewBag.BackText = "Go Back";
            return View("NotFound");
        }
    }
}
