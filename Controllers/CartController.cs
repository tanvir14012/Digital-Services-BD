using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Digital_Services_BD.Migrations;
using Digital_Services_BD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class CartController : Controller
    {
        private readonly ICartOps cartOps;

        public CartController(ICartOps cartOps)
        {
            this.cartOps = cartOps;
        }
        [HttpGet]
        public IActionResult Index([FromQuery] int? userId)
        {
            if(ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartView = cartOps.GetCart(cartId, userId);
                if(cartView != null)
                {
                    if(cartView.IsCreatedNow)
                    {
                        var option = new CookieOptions();
                        option.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Append("CartId", cartView.CartId.ToString(), option);
                    }
                    return View(cartView);
                }
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult AddToCart( int? userId, int itemId, int addQuantity, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItem = cartOps.AddCartItemtoCart(cartIdFromCookie, userId, itemId, addQuantity);
                if(cartItem != null)
                {
                    TempData["Message"] = "Success! The item has been added to your cart.";
                    TempData["AlertClass"] = "alert alert-info alert-dismissible fade show";
                }
                else
                {
                    TempData["Message"] = "Sorry! Some error occurred while adding the item to your cart. Please try again.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                }
                return LocalRedirect(returnUrl);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public IActionResult BuyNow(int? userId2, int itemId2, int buyQuantity, string returnUrl2)
        {
            if(ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItem = cartOps.AddCartItemtoCart(cartIdFromCookie, userId2, itemId2, buyQuantity);
                if(cartItem != null)
                {
                    return RedirectToAction("Index", new { userId = userId2 });
                }
                else
                {
                    TempData["Message"] = "Sorry! Some error occurred while adding the item to your cart. Please try again.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                    return LocalRedirect(returnUrl2);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
