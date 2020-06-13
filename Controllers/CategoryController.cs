using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
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
            [FromQuery] string SortBy = null, [FromQuery] string priceRange = null)
        {
            if(ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    ViewBag.Id = productGroup.Id;
                    ViewBag.ProductGroupName = productGroup.Name;
                    ViewBag.TotalCategory = productGroupOps.GetAllProdCategoriesByProdGroupId(id).Count();
                    ViewBag.PageNo = pageNo;
                    return View(productGroup.AllCategories.ToList());
                }
            }
      
            return View("NotFound");
        }
    }
}
