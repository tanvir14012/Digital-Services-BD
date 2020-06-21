using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Digital_Services_BD.Migrations;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
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
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartView = cartOps.GetCart(cartId, userId);
                if (cartView != null)
                {
                    if (cartView.IsCreatedNow)
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
        public IActionResult Index(int cartId, List<CartItemIdQty> cartItemIdNquantity, int? cartItemIdToBeDeleted)
        {
            if (ModelState.IsValid)
            {
                if (cartOps.DoesCartExist(cartId))
                {
                    //Delete 
                    if (cartItemIdToBeDeleted != null)
                    {
                        var cartItem = cartOps.DeleteCartItemFromCart(cartId, (int)cartItemIdToBeDeleted);
                        if (cartItem == null) //Delete unsuccessful
                        {
                            ViewBag.DeleteMsg = "Sorry! Some error occurred while deleting the item from your cart. Please try again.";
                        }
                    }
                    else // Update quantity
                    {
                        foreach (var itemIdQty in cartItemIdNquantity)
                        {
                            cartOps.UpdateQuantity(itemIdQty.CartItemId, itemIdQty.Quantity);
                        }
                    }

                    var cartView = cartOps.GetCart(cartId, null);
                    if (cartView != null)
                    {
                        return View(cartView);
                    }
                }
            }
            return View(null);
        }

        [HttpPost]
        public IActionResult AddToCart(int? userId, int itemId, int addToCartQuantity, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItemView = cartOps.AddCartItemtoCart(cartIdFromCookie, userId, itemId, addToCartQuantity);
                if (cartItemView != null)
                {
                    if(cartItemView.IsCartCreatedWhenAdded)
                    {
                        var cookieOps = new CookieOptions();
                        cookieOps.Expires = DateTime.UtcNow.AddMonths(6);
                        Response.Cookies.Append("CartId", cartItemView.CreatedCartId.ToString(), cookieOps);
                    }
                    if(cartItemView.Message != null)
                    {
                        TempData["Message"] = cartItemView.Message;
                        TempData["AlertClass"] = cartItemView.MessageClass;
                    }
                    else
                    {
                        TempData["Message"] = "Success! The item has been added to your cart.";
                        TempData["AlertClass"] = "alert alert-success alert-dismissible fade show";
                    }
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
        public IActionResult BuyNow(int? userId2, int itemId2, int buyNowQuantity, string returnUrl2)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"\d{0,2147483647}")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItem = cartOps.AddCartItemtoCart(cartIdFromCookie, userId2, itemId2, buyNowQuantity);
                if (cartItem != null)
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
