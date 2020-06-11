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
        private readonly IProductItemOps productItemOps;
        private readonly IProductSectionOps productSectionOps;
        private readonly ICarouselOps carouselOps;

        public AdminController(IProductGroupOps productGroupOps, IProductCategoryOps productCategoryOps,
            IProductItemOps productItemOps, IProductSectionOps productSectionOps, ICarouselOps carouselOps)
        {
            this.productGroupOps = productGroupOps;
            this.productCategoryOps = productCategoryOps;
            this.productItemOps = productItemOps;
            this.productSectionOps = productSectionOps;
            this.carouselOps = carouselOps;
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

        #region ProductItem
        public IActionResult ProductItem()
        {
            return View(productItemOps.GetAllProductItems());
        }
        public IActionResult CreateProductItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductItem(ProductItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productItemModel = productItemOps.ConvertViewModelToModel(model);
                var productItem = productItemOps.AddProductItem(productItemModel);
                if (productItem != null)
                {
                    return RedirectToAction("ProductItem");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while adding the item to database");
            }
            return View(model);
        }
        public IActionResult ViewProductItem(int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = productItemOps.GetProductItem(id);
                if (productItem != null)
                {
                    return View(productItem);
                }
            }
            ViewBag.Heading = "Product Item Not Found";
            ViewBag.Message = "The product item is not found on the system";
            ViewBag.Action = "ProductItem";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProductItem(int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = productItemOps.GetProductItem(id);
                if (productItem != null)
                {
                    var productItemViweModel = productItemOps.ConvertModelToViewModel(productItem);
                    return View(productItemViweModel);
                }
            }
            ViewBag.Heading = "Product Item Not Found";
            ViewBag.Message = "The product item is not found on the system";
            ViewBag.Action = "ProductItem";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item";
            return View("NotFound");
        }
        [HttpPost]
        public IActionResult EditProductItem(ProductItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productItemModel = productItemOps.ConvertViewModelToModel(model);
                var productItem = productItemOps.UpdateProductItem(productItemModel);
                if (productItem != null)
                {
                    return RedirectToAction("ProductItem");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while updating the item to database");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteProductItem(int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = productItemOps.GetProductItem(id);
                if (productItem != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = productItem.Id;
                    ViewBag.Action = "DeleteProductItemConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "ProductItem";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Product Item Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the product item permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Product Item Not Found";
            ViewBag.Message = "The product item is not found on the system";
            ViewBag.Action = "ProductItem";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item";
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteProductItemConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = productItemOps.DeleteProductItem(id);
                if (productItem != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The product item has been deleted successfully.";
                    ViewBag.Action = "ProductItem";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product item";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the product item. Please try again later.";
                    ViewBag.Action = "ProductItem";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product item";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "ProductItem";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item";
            return View("NotFound");
        }
        #endregion

        #region ProductSection
        public IActionResult ProductSection()
        {
            return View(productSectionOps.GetAllProductSections().ToList());
        }
        public IActionResult CreateProductSection()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductSection(ProductSection model)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.AddProductSection(model);
                if (productSection != null)
                {
                    return RedirectToAction("ProductSection");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while adding the item to database");
            }
            return View(model);
        }
        public IActionResult ViewProductSection(int id)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.GetProductSection(id);
                if (productSection != null)
                {
                    return View(productSection);
                }
            }
            ViewBag.Heading = "Product Section Not Found";
            ViewBag.Message = "The product section is not found on the system";
            ViewBag.Action = "ProductSection";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product section";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProductSection(int id)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.GetProductSection(id);
                if (productSection != null)
                {
                    return View(productSection);
                }
            }
            ViewBag.Heading = "Product Section Not Found";
            ViewBag.Message = "The product section is not found on the system";
            ViewBag.Action = "ProductSection";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product section";
            return View("NotFound");
        }
        [HttpPost]
        public IActionResult EditProductSection(ProductSection model)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.UpdateProductSection(model);
                if (productSection != null)
                {
                    return RedirectToAction("ProductSection");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while updating the item to database");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteProductSection(int id)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.GetProductSection(id);
                if (productSection != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = productSection.Id;
                    ViewBag.Action = "DeleteProductSectionConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "ProductSection";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Product Section Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the product section permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Product Section Not Found";
            ViewBag.Message = "The product section is not found on the system";
            ViewBag.Action = "ProductSection";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product section";
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteProductSectionConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.DeleteProductSection(id);
                if (productSection != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The product section has been deleted successfully.";
                    ViewBag.Action = "ProductSection";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product section";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the product section. Please try again later.";
                    ViewBag.Action = "ProductSection";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product section";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "ProductSection";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product section";
            return View("NotFound");
        }
        #endregion

        #region Carousel
        [HttpGet]
        public IActionResult Carousel()
        {
            return View(carouselOps.GetAllCarousel().ToList());
        }
        [HttpGet]
        public IActionResult CreateCarousel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCarousel(Carousel model)
        {
            if(ModelState.IsValid)
            {
                var carousel = carouselOps.AddCarousel(model);
                if(carousel != null)
                {
                    return RedirectToAction("Carousel");
                }
                ModelState.AddModelError(string.Empty, "Some error occureed while adding the item to database");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewCarousel(int id)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.GetCarousel(id);
                if (carousel != null)
                {
                    return View(carousel);
                }
            }
            ViewBag.Heading = "Carousel Not Found";
            ViewBag.Message = "The carousel is not found on the system";
            ViewBag.Action = "Carousel";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to carousel";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditCarousel(int id)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.GetCarousel(id);
                if (carousel != null)
                {
                    return View(carousel);
                }
            }
            ViewBag.Heading = "Carousel Not Found";
            ViewBag.Message = "The carousel is not found on the system";
            ViewBag.Action = "Carousel";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to carousel";
            return View("NotFound");
        }
        [HttpPost]
        public IActionResult EditCarousel(Carousel model)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.UpdateCarousel(model);
                if (carousel != null)
                {
                    return RedirectToAction("Carousel");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Some error occureed while updating the item to database");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteCarousel(int id)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.GetCarousel(id);
                if (carousel != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = carousel.Id;
                    ViewBag.Action = "DeleteCarouselConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "Carousel";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Carousel Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the carousel permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Carousel Not Found";
            ViewBag.Message = "The carousel is not found on the system";
            ViewBag.Action = "Carousel";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to carousel";
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteCarouselConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.DeleteCarousel(id);
                if (carousel != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The carousel has been deleted successfully.";
                    ViewBag.Action = "Carousel";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to carousel";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the carousel. Please try again later.";
                    ViewBag.Action = "Carousel";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to carousel";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "Carousel";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to carousel";
            return View("NotFound");
        }
        #endregion
    }

}
