using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Migrations;
using Digital_Services_BD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{id?}")]
    public class CartController : Controller
    {
        private readonly ICartOps cartOps;

        public CartController(ICartOps cartOps)
        {
            this.cartOps = cartOps;
        }
        [HttpGet]
        public IActionResult Index([FromRoute] int? id, [FromQuery] int? userId)
        {
            if(ModelState.IsValid)
            {
                var cartView = cartOps.GetCart(id, userId);
                if(cartView != null)
                {
                    return View(cartView);
                }
            }
            return View();
        }
    }
}
