using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Utilities;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{action=Index}")]
    [Authorize(Policy = "AdminFullAccess")]
    public class ProductStocksController : Controller
    {
        private readonly IProductStockOps productStockOps;
        private readonly AppDbContext dbContext;

        public ProductStocksController(IProductStockOps productStockOps, AppDbContext dbContext)
        {
            this.productStockOps = productStockOps;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            try
            {
                var model = await productStockOps.FilterProductStocks();
                ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
                return View(model);
            }
            catch
            {
                ViewBag.Heading = "Something went wrong!";
                ViewBag.HeadingClass = "alert-danger";
                ViewBag.Message = "An error occurred while retrieving your product stocks." +
                    " Please try again later.";
                return View("AlertMessage");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FilteredProductStocks model)
        {
            try
            {
                var filteredModel = await productStockOps.FilterProductStocks(model.GroupId,
                    model.CategoryId, model.ProductId, model.PageNo, model.ProductStockPerPage, model.SortBy);
                ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
                return View(filteredModel);
            }
            catch
            {
                ViewBag.Heading = "Something went wrong!";
                ViewBag.HeadingClass = "alert-danger";
                ViewBag.Message = "An error occurred while retrieving your product stocks. Please try again later.";
                return View("AlertMessage");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int Id)
        {
            var productStock = await productStockOps.GetProductStock(Id);
            if (productStock == null)
            {
                return View("NotFound");
            }
            return View(productStock);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var model = await productStockOps.AddProductStock(productStock);
                    if (model != null)
                    {
                        ViewBag.Message = $"Success! The product stock has been added.";
                        ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "An error occurred while saving.";
                    }
                }
                catch
                {
                    ViewBag.Message = "Unknown error! The product stock has not been added.";
                }

            }
            ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
            return View(productStock);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var productStock = await productStockOps.GetProductStock(Id);
            if (productStock != null)
            {
                ViewBag.Title = "Confirm Delete";
                ViewBag.Id = productStock.Id;
                ViewBag.Action = "DeleteConfirm";
                ViewBag.Controller = "ProductStocks";
                ViewBag.CancelAction = "Index";
                ViewBag.CancelController = "ProductStocks";
                ViewBag.Heading = "Confirm Product Item Stock Deletion";
                ViewBag.HeadingClass = "alert-danger";
                ViewBag.Message = "The following action will delete the product item stock" +
                    " permanently from the system, which can not be undone.";
                return View("Confirmation");
            }

            ViewBag.Heading = "Product Stock Not Found";
            ViewBag.Message = "The product item's stock is not found on the system";
            ViewBag.Action = "Index";
            ViewBag.Controller = "ProductStocks";
            ViewBag.BackText = "Go to product stocks";
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
            var productStock = await productStockOps.DeleteProductStock(Id);
            if (productStock == null)
            {
                ViewBag.Heading = "Failed!";
                ViewBag.HeadingClass = "alert-danger";
                ViewBag.Message = "The product stock could not be deleted.";
            }

            else
            {
                ViewBag.Heading = "Success!";
                ViewBag.HeadingClass = "alert-success";
                ViewBag.Message = "The product stock has been deleted successfully.";
            }
            
            ViewBag.Action1 = "Index";
            ViewBag.Controller1 = "ProductStocks";
            ViewBag.LinkText1 = "Product stocks";
            return View("AlertMessage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var productStock = await productStockOps.GetProductStock(id);
            if (productStock != null)
            {
                ViewBag.ProductHierarchy = await productStockOps.GetProductHierarchy();
                return View(productStock);
            }

            ViewBag.Heading = "Product Stock Not Found";
            ViewBag.Message = "The product item's stock is not found on the system";
            ViewBag.Action = "Index";
            ViewBag.Controller = "ProductStocks";
            ViewBag.BackText = "Go to product stocks";
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductStock model)
        {
            if (ModelState.IsValid)
            {
                var productStock = await productStockOps.UpdateProductStock(model);
                if (productStock != null)
                {
                    return View("Details", productStock);
                }
            }

            ViewBag.Heading = "Update Failed!";
            ViewBag.HeadingClass = "alert-success";
            ViewBag.Message = "The product stock update failed.";
            ViewBag.Action1 = "Index";
            ViewBag.Controller1 = "ProductStocks";
            ViewBag.LinkText1 = "Product stocks";
            return View("AlertMessage");
        }
    }
}
