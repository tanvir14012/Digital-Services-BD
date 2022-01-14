using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class OrdersController : Controller
    {
        private readonly IOrderOps orderOps;
        private readonly IConfiguration configuration;

        public OrdersController(IOrderOps orderOps, IConfiguration configuration)
        {
            this.orderOps = orderOps;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId != null)
            {
                try
                {
                    var total = await orderOps.GetOrderCount(userId);
                    var model = await orderOps.FilterOrders(userId, total);
                    
                    model.TotalOrders = total;
                    return View(model);
                }
                catch (Exception ex)
                {
                    ViewBag.Heading = "Something went wrong!";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "An error occurred while retrieving your orders." +
                        " Please try again later.";
                    ViewBag.Action1 = "Index";
                    ViewBag.Controller1 = "Home";
                    ViewBag.LinkText1 = "Home";
                    return View("AlertMessage");
                }
                
            }
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(referer) ? "/": referer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FilteredOrders model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                try
                {
                    var filteredModel = await orderOps.FilterOrders(userId, model.TotalOrders, model.PageNo, model.OrderPerPage, model.SortBy);
                    return View(filteredModel);
                }
                catch
                {
                    ViewBag.Heading = "Something went wrong!";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "An error occurred while retrieving your orders. Please try again later.";
                    ViewBag.Action1 = "Index";
                    ViewBag.Controller1 = "Home";
                    ViewBag.LinkText1 = "Home";
                    return View("AlertMessage");
                }
            }
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(referer) ? "/" : referer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int Id)
        {
            var order = await orderOps.GetOrder(Id);
            if(order == null)
            {
                return View("NotFound");
            }
            if(order.CustomerId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized();
            }
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExportInvoice(int orderId)
        {
            var order = await orderOps.GetOrder(orderId);
            if (order != null)
            {
                ViewData["Shopname"] = configuration["Contact:Name"];
                ViewData["ShopAddress1"] = configuration["Contact:Address1"];
                ViewData["ShopAddress2"] = configuration["Contact:Address2"];
                ViewData["Website"] = configuration["Contact:Website"];
                ViewData["Phone"] = configuration["Contact:Phone"];
                ViewData["Email"] = configuration["Contact:Email"];
                return new ViewAsPdf("ExportInvoice", order, ViewData)
                {
                    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                };
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
