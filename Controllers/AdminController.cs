using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IProductGroupOps productGroupOps;
        private readonly IProductCategoryOps productCategoryOps;

        public AdminController(IProductGroupOps productGroupOps, IProductCategoryOps productCategoryOps)
        {
            this.productGroupOps = productGroupOps;
            this.productCategoryOps = productCategoryOps;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region ProductGroup
        public IActionResult ProductGroup()
        {
            return View(productGroupOps.GetAllProductGroups());
        }
        public IActionResult CreateProductGroup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductGroup(ProductGroup model)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.AddProductGroup(model);
                if (productGroup != null)
                {
                    return RedirectToAction("ProductGroup");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while adding the item to database");
            }
            return View(model);
        }
        public IActionResult ViewProductGroup(int id)
        {
            if(ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    return View(productGroup);
                }
            }
            ViewBag.Heading = "Product Group Not Found";
            ViewBag.Message = "The product group is not found on the system";
            ViewBag.Action = "ProductGroup";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product group";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProductGroup(int id)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    return View(productGroup);
                }
            }
            ViewBag.Heading = "Product Group Not Found";
            ViewBag.Message = "The product group is not found on the system";
            ViewBag.Action = "ProductGroup";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product group";
            return View("NotFound");
        }
        [HttpPost]
        public IActionResult EditProductGroup(ProductGroup model)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.UpdateProductGroup(model);
                if (productGroup != null)
                {
                    return RedirectToAction("ProductGroup");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while updating the item to database");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteProductGroup(int id)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = productGroup.Id;
                    ViewBag.Action = "DeleteProductGroupConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "ProductGroup";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Product Group Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the product group permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Product Group Not Found";
            ViewBag.Message = "The product group is not found on the system";
            ViewBag.Action = "ProductGroup";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product group";
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteProductGroupConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.DeleteProductGroup(id);
                if (productGroup != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The product group has been deleted successfully.";
                    ViewBag.Action = "ProductGroup";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product group";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the product group. Please try again later.";
                    ViewBag.Action = "ProductGroup";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product group";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "ProductGroup";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product group";
            return View("NotFound");
        }
        #endregion

        #region ProductCategory
        public IActionResult ProductCategory()
        {
            return View(productCategoryOps.GetAllProductCategories());
        }
        public IActionResult CreateProductCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductCategory(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.AddProductCategory(model);
                if (productCategory != null)
                {
                    return RedirectToAction("ProductCategory");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while adding the item to database");
            }
            return View(model);
        }
        public IActionResult ViewProductCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.GetProductCategory(id);
                if (productCategory != null)
                {
                    return View(productCategory);
                }
            }
            ViewBag.Heading = "Product Category Not Found";
            ViewBag.Message = "The product category is not found on the system";
            ViewBag.Action = "ProductCategory";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product category";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProductCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.GetProductCategory(id);
                if (productCategory != null)
                {
                    return View(productCategory);
                }
            }
            ViewBag.Heading = "Product Category Not Found";
            ViewBag.Message = "The product category is not found on the system";
            ViewBag.Action = "ProductCategory";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product category";
            return View("NotFound");
        }
        [HttpPost]
        public IActionResult EditProductCategory(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.UpdateProductCategory(model);
                if (productCategory != null)
                {
                    return RedirectToAction("ProductCategory");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while updating the item to database");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteProductCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.GetProductCategory(id);
                if (productCategory != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = productCategory.Id;
                    ViewBag.Action = "DeleteProductCategoryConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "ProductCategory";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Product Category Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the product category permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Product Category Not Found";
            ViewBag.Message = "The product category is not found on the system";
            ViewBag.Action = "ProductCategory";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product category";
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteProductCategoryConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.DeleteProductCategory(id);
                if (productCategory != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The product category has been deleted successfully.";
                    ViewBag.Action = "ProductCategory";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product category";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the product category. Please try again later.";
                    ViewBag.Action = "ProductCategory";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product category";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "ProductCategory";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product category";
            return View("NotFound");
        }
        #endregion
    }

}
