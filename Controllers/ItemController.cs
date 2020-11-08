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
    public class ItemController : Controller
    {
        private readonly IProductCategoryOps productCategoryOps;
        private readonly IProductItemOps productItemOps;

        public ItemController(IProductCategoryOps productCategoryOps, IProductItemOps productItemOps)
        {
            this.productCategoryOps = productCategoryOps;
            this.productItemOps = productItemOps;
        }
        public IActionResult Index([FromRoute] int id, [FromQuery] int pageNo = 1,
            [FromQuery] string sortBy = null, [FromQuery] string priceRange = null)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.GetProductCategory(id);
                if (productCategory != null)
                {
                    var filteredItems = productCategoryOps.FilterItems(productCategory.Id, pageNo - 1, sortBy, priceRange);
                    ViewBag.Id = productCategory.Id;
                    ViewBag.ProductCategoryName = productCategory.Name;
                    ViewBag.TotalItem = filteredItems.TotalItems;
                    ViewBag.PageNo = pageNo;
                    ViewBag.SortBy = sortBy ?? "m_p";
                    if (priceRange != null && Regex.IsMatch(priceRange, @"^\d+to\d+$"))
                    {
                        ViewBag.PriceMin = Convert.ToInt32(priceRange.Split("to")[0]);
                        ViewBag.PriceMax = Convert.ToInt32(priceRange.Split("to")[1]);
                    }
                    else
                    {
                        ViewBag.PriceMin = ProductConfig.MinPrice;
                        ViewBag.PriceMax = ProductConfig.MaxPrice;
                    }
                    return View(filteredItems.ItemsUnderFilter);
                }
            }
            ViewBag.Heading = "Page Not Found";
            ViewBag.Message = "This is not the page you are looking for. Please check spelling and try again.";
            ViewBag.Action = "Index";
            ViewBag.Controller = "Item";
            ViewBag.BackText = "Go Back";
            return View("NotFound");
        }
    }
}
