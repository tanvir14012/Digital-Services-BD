using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Services;

using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{id}")]
    public class DetailController : Controller
    {
        private readonly IProductItemOps productItemOps;
        private readonly IProductItemBundleOps productItemBundleOps;

        public DetailController(IProductItemOps productItemOps, IProductItemBundleOps productItemBundleOps)
        {
            this.productItemOps = productItemOps;
            this.productItemBundleOps = productItemBundleOps;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = await productItemOps.GetProductItemAsync(id);
                if (productItem != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.AlertClass = TempData["AlertClass"];
                    ViewBag.Bundles = await productItemBundleOps.GetAllProductItemBundlesAsync(id);
                    return View(productItem);
                }

            }
            ViewBag.Heading = "Page Not Found";
            ViewBag.Message = "This is not the page you are looking for. Please check spelling and try again.";
            ViewBag.Action = "Index";
            ViewBag.Controller = "Home";
            ViewBag.BackText = "Go Home";
            return View("NotFound");

        }
    }
}
