using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Services;

using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{id}")]
    public class PackageController : Controller
    {
        private readonly IProductItemBundleOps productItemBundleOps;

        public PackageController(IProductItemBundleOps productItemBundleOps)
        {
            this.productItemBundleOps = productItemBundleOps;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var bundle = await productItemBundleOps.GetProductItemBundleAsync(id);
                if (bundle != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.AlertClass = TempData["AlertClass"];
                    return View(bundle);
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
