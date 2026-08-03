using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Utilities;
using Digital_Services_BD.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Policy = "AdminFullAccess")]
    public class AdminController : Controller
    {
        private readonly IProductGroupOps productGroupOps;
        private readonly IProductCategoryOps productCategoryOps;
        private readonly IProductItemOps productItemOps;
        private readonly IProductSectionOps productSectionOps;
        private readonly ICarouselOps carouselOps;
        private readonly IProductItemBundleOps productItemBundleOps;
        private readonly AppDbContext dbContext;

        public AdminController(IProductGroupOps productGroupOps, IProductCategoryOps productCategoryOps,
            IProductItemOps productItemOps, IProductSectionOps productSectionOps, ICarouselOps carouselOps,
            IProductItemBundleOps productItemBundleOps, AppDbContext dbContext)
        {
            this.productGroupOps = productGroupOps;
            this.productCategoryOps = productCategoryOps;
            this.productItemOps = productItemOps;
            this.productSectionOps = productSectionOps;
            this.carouselOps = carouselOps;
            this.productItemBundleOps = productItemBundleOps;
            this.dbContext = dbContext;
        }
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
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
            ViewBag.Categories = productCategoryOps.GetAllProductCategories().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
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

            ViewBag.Categories = productCategoryOps.GetAllProductCategories().ToList();
            return View(model);
        }
        public IActionResult ViewProductGroup(int id)
        {
            if (ModelState.IsValid)
            {
                var productGroup = productGroupOps.GetProductGroup(id);
                if (productGroup != null)
                {
                    ViewBag.Categories = productGroupOps.GetAllProdCategoriesByProdGroupId(id);
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
                    ViewBag.ThisGroupCategories = productGroupOps.GetAllProdCategoriesByProdGroupId(id).ToList();
                    ViewBag.AllCategories = productCategoryOps.GetAllProductCategories().ToList();
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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
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
            ViewBag.Items = productItemOps.GetAllProductItems().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
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

            ViewBag.Items = productItemOps.GetAllProductItems().ToList();
            return View(model);
        }
        public IActionResult ViewProductCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var productCategory = productCategoryOps.GetProductCategory(id);
                if (productCategory != null)
                {
                    ViewBag.ProductItems = productItemOps.GetAllProdItemByProdCatgId(id);
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
                    ViewBag.ItemsThisCategory = productItemOps.GetAllProdItemByProdCatgId(id).ToList();
                    ViewBag.AllItems = productItemOps.GetAllProductItems().ToList();

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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
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
            ViewBag.Categories = productCategoryOps.GetAllProductCategories().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
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

            ViewBag.Categories = productCategoryOps.GetAllProductCategories().ToList();
            return View(model);
        }
        public IActionResult ViewProductItem(int id)
        {
            if (ModelState.IsValid)
            {
                var productItem = productItemOps.GetProductItem(id);
                if (productItem != null)
                {
                    ViewBag.Categories = productCategoryOps.GetAllProdCategoryByProdItemId(id);

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
                    ViewBag.ThisItemCategories = productCategoryOps.GetAllProdCategoryByProdItemId(id);
                    ViewBag.AllCategories = productCategoryOps.GetAllProductCategories().ToList();
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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
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
            ViewBag.Items = productItemOps.GetAllProductItems().ToList();
            ViewBag.Ranks = productSectionOps.GetAvailableRanks().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
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

            ViewBag.Items = productItemOps.GetAllProductItems().ToList();
            ViewBag.Ranks = productSectionOps.GetAvailableRanks().ToList();
            return View(model);
        }
        public IActionResult ViewProductSection(int id)
        {
            if (ModelState.IsValid)
            {
                var productSection = productSectionOps.GetProductSection(id);
                if (productSection != null)
                {
                    ViewBag.Items = productSectionOps.GetAllProdItemsByProdSectionId(id);

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
                    ViewBag.ThisSectionItems = productSectionOps.GetAllProdItemsByProdSectionId(id).ToList();
                    ViewBag.AllItems = productItemOps.GetAllProductItems().ToList();
                    ViewBag.AllProductSections = productSectionOps.GetAllProductSections().ToList();
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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
        public IActionResult CreateCarousel(Carousel model)
        {
            if (ModelState.IsValid)
            {
                var carousel = carouselOps.AddCarousel(model);
                if (carousel != null)
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
        [ValidateAntiForgeryToken()]
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
        [ValidateAntiForgeryToken()]
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

        [HttpGet]
        public IActionResult PaymentGw()
        {
            var model = dbContext.PaymentGwConfigs.OrderBy(gwc => gwc.CreatedOn)
                .FirstOrDefault();

            if (model == null)
            {
                model = new PaymentGwConfig
                {
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                };
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PaymentGw(PaymentGwConfig model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Id == null)
                    {
                        dbContext.PaymentGwConfigs.Add(model);
                    }
                    else
                    {
                        dbContext.PaymentGwConfigs.Update(model);
                    }
                    dbContext.SaveChanges();
                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving");
                }

            }

            return View(model);
        }


        [HttpGet]
        public IActionResult EmailConfig()
        {
            var model = dbContext.SmtpConfigs.OrderByDescending(cfg => cfg.CreatedDateTime)
                .FirstOrDefault();

            if (model == null)
            {
                model = new SmtpConfig
                {
                    Id = null,
                    CreatedDateTime = DateTime.UtcNow,
                    UpdatedDateTime = DateTime.UtcNow
                };
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmailConfig(SmtpConfig model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Id == null)
                    {
                        dbContext.SmtpConfigs.Add(model);
                    }
                    else
                    {
                        dbContext.SmtpConfigs.Update(model);
                    }
                    dbContext.SaveChanges();
                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving");
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CheckEncryptionKey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult CheckEncryptionKey(Key model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbModel = dbContext.EncryptionKeys.FirstOrDefault();
                    if (dbModel != null)
                    {
                        var matched = PasswordUtility.VerifyHashedPassword(dbModel.Key, model.Value);
                        if (!matched)
                        {
                            ModelState.AddModelError(string.Empty, "The key is incorrect.");
                            return View(model);
                        }
                        else
                        {
                            ViewBag.Message = "Correct! The given key is accurate.";
                            return View(new Key { });
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Could not find the entry in database.");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while querying the database.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateEncryptionKey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult UpdateEncryptionKey(UpdateEncryptionKey model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbModel = dbContext.EncryptionKeys.FirstOrDefault();
                    if (dbModel != null)
                    {
                        var matched = PasswordUtility.VerifyHashedPassword(dbModel.Key, model.OldKey);
                        if (!matched)
                        {
                            ModelState.AddModelError(string.Empty, "Old key is incorrect.");
                            return View(model);
                        }
                        var hash = PasswordUtility.HashPassword(model.NewKey);
                        dbModel.Key = hash;
                        dbModel.LastUpdated = DateTime.UtcNow;
                        dbContext.SaveChanges();
                        ViewBag.Message = "Update Successful!";
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Could not find the entry in database.");
                    }

                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving");
                }
            }
            return View(model);
        }


        #region ProductItemBundle
        public IActionResult ProductItemBundle()
        {
            return View(productItemBundleOps.GetAllProductItemBundles().ToList());
        }

        [HttpGet]
        public IActionResult CreateProductItemBundle()
        {
            ViewBag.Items = JsonConvert.SerializeObject(productItemOps.GetAllProductItems().ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult CreateProductItemBundle(ProductItemBundle model)
        {
            if (ModelState.IsValid && model.ProductItemBundleJoinProductItem.Count > 1
                && model.ProductItemBundleJoinProductItem.Count == model.ProductItemBundleJoinProductItem.GroupBy(join => join.ProductItemId).Count())
            {
                var ProductItemBundle = productItemBundleOps.AddProductItemBundle(model);
                if (ProductItemBundle != null)
                {
                    return RedirectToAction("ProductItemBundle");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while adding the item to database.");
            }
            ViewBag.Items = JsonConvert.SerializeObject(productItemOps.GetAllProductItems().ToList());
            ModelState.AddModelError(string.Empty, "Duplicate or inconsistent input error.");
            return View(model);
        }
        public IActionResult ViewProductItemBundle(int id)
        {
            if (ModelState.IsValid)
            {
                var ProductItemBundle = productItemBundleOps.GetProductItemBundle(id);
                if (ProductItemBundle != null)
                {
                    return View(ProductItemBundle);
                }
            }
            ViewBag.Heading = "Product Item Bundle Not Found";
            ViewBag.Message = "The product item budle is not found on the system";
            ViewBag.Action = "ProductItemBundle";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item bundle";
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProductItemBundle(int id)
        {
            if (ModelState.IsValid)
            {
                var ProductItemBundle = productItemBundleOps.GetProductItemBundle(id);
                if (ProductItemBundle != null)
                {
                    ViewBag.Items = JsonConvert.SerializeObject(productItemOps.GetAllProductItems().ToList());
                    return View(ProductItemBundle);
                }
            }
            ViewBag.Heading = "Product Item Bundle Not Found";
            ViewBag.Message = "The product item bundle is not found on the system";
            ViewBag.Action = "ProductItemBundle";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product item bundle";
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult EditProductItemBundle(ProductItemBundle model)
        {
            if (ModelState.IsValid && model.ProductItemBundleJoinProductItem.Count > 1 &&
                model.ProductItemBundleJoinProductItem.Count == model.ProductItemBundleJoinProductItem.GroupBy(join => join.ProductItemId).Count())
            {
                var ProductItemBundle = productItemBundleOps.UpdateProductItemBundle(model);
                if (ProductItemBundle != null)
                {
                    return RedirectToAction("ProductItemBundle");
                }
                ModelState.AddModelError(string.Empty, "Some error occurred while updating the item to database");
            }

            ModelState.AddModelError(string.Empty, "Duplicate or inconsistent input error.");
            ViewBag.Items = JsonConvert.SerializeObject(productItemOps.GetAllProductItems().ToList());
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteProductItemBundle(int id)
        {
            if (ModelState.IsValid)
            {
                var ProductItemBundle = productItemBundleOps.GetProductItemBundle(id);
                if (ProductItemBundle != null)
                {
                    ViewBag.Title = "Confirm Delete";
                    ViewBag.Id = ProductItemBundle.Id;
                    ViewBag.Action = "DeleteProductItemBundleConfirm";
                    ViewBag.Controller = "Admin";
                    ViewBag.CancelAction = "ProductItemBundle";
                    ViewBag.CancelController = "Admin";
                    ViewBag.Heading = "Confirm Product Bundle Deletion";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "The following action will delete the product bundle permanently from the system, which can not be undone.";
                    return View("Confirmation");
                }
            }
            ViewBag.Heading = "Product Bundle Not Found";
            ViewBag.Message = "The product bundle is not found on the system";
            ViewBag.Action = "ProductItemBundle";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product bundle";
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult DeleteProductItemBundleConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var ProductItemBundle = productItemBundleOps.DeleteProductItemBundle(id);
                if (ProductItemBundle != null)
                {
                    ViewBag.Title = "Delete Successful";
                    ViewBag.Heading = "Success";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = "The product bundle has been deleted successfully.";
                    ViewBag.Action = "ProductItemBundle";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product bundle";
                }
                else
                {
                    ViewBag.Title = "Delete Failed";
                    ViewBag.Heading = "Fail";
                    ViewBag.HeadingClass = "alert-danger";
                    ViewBag.Message = "Some error occurred while deleting the product bundle. Please try again later.";
                    ViewBag.Action = "ProductItemBundle";
                    ViewBag.Controller = "Admin";
                    ViewBag.BackText = "Go to product bundle";
                }
                return View("SuccessFailure");
            }

            ViewBag.Action = "ProductItemBundle";
            ViewBag.Controller = "Admin";
            ViewBag.BackText = "Go to product bundle";
            return View("NotFound");
        }
    }
    #endregion

}
