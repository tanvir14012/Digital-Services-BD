using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{id}")]
    public class Detail : Controller
    {
        private readonly IProductItemOps productItemOps;

        public Detail(IProductItemOps productItemOps)
        {
            this.productItemOps = productItemOps;
        }

        [HttpGet]
        public IActionResult Index([FromRoute] int id)
        {
            if(ModelState.IsValid)
            {
                var productItem = productItemOps.GetProductItem(id);
                if(productItem != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.AlertClass = TempData["AlertClass"];
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
