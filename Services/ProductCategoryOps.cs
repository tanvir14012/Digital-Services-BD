using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Digital_Services_BD.Services
{
    public class ProductCategoryOps : IProductCategoryOps
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductCategoryOps(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// Adds a ProductCategory to database, saves the image to wwwroot/imageresource/ProductCategory folder,
        /// stores the relative link to database column imageUrl
        /// </summary>
        /// <param name="ProductCategory">the ProductCategory model</param>
        /// <returns>returns added item if successful, otherwise returns null</returns>
        public ProductCategory AddProductCategory(ProductCategory productCategory)
        {
            if (productCategory.Image != null)
            {
                productCategory.ImageUrl = SaveProductImage(productCategory.Image);
            }
            productCategory.CreatedOn = DateTime.UtcNow;
            productCategory.LastModifiedOn = DateTime.UtcNow;
            context.ProductCategories.Add(productCategory);
            try
            {
                var isSaved = context.SaveChanges() > 0;
                //Add product item under this product category
                if (productCategory.AllItemIds.Count > 0)
                {
                    var isAdded = AddProdItemsToCategory(productCategory.Id, productCategory.AllItemIds);
                    if (!isAdded)
                    {
                        return null;
                    }
                }
                return isSaved ? productCategory : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Delete ProductCategory from database
        /// </summary>
        /// <param name="id">
        /// Id of ProductCategory in database
        /// </param>
        /// <returns>
        /// returns deleted item if successful, otherwise returns null
        /// </returns>
        public ProductCategory DeleteProductCategory(int id)
        {
            var productCategory = context.ProductCategories.Find(id);
            if (productCategory != null)
            {
                context.ProductCategories.Remove(productCategory);
            }
            try
            {
                if (context.SaveChanges() > 0)
                {
                    DeleteFile(productCategory.ImageUrl);
                    return productCategory;
                };
                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public IEnumerable<ProductCategory> GetAllProdCategoryByProdItemId(int productItemId)
        {
            var query = from category in context.ProductCategories
                        join itemcategorymap in context.ProductItemJoinProductCategory
                        on category.Id equals itemcategorymap.ProductCategoryId
                        where itemcategorymap.ProductItemId == productItemId
                        select category;

            return query.ToList();
        }

        /// <summary>
        /// Get all ProductCategory
        /// </summary>
        /// <returns>returns a list of ProductCategory</returns>
        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return context.ProductCategories.AsNoTracking().ToList();
        }
        /// <summary>
        /// Get ProductCategory by id
        /// </summary>
        /// <param name="id">Id of ProductCategory</param>
        /// <returns>returns null if not found</returns>
        public ProductCategory GetProductCategory(int id)
        {
            var productCategory = context.ProductCategories.Find(id);
            //Populate associated product items for details view
            if (productCategory != null)
            {
                productCategory.AllItems = GetAllProdItemByProdCatgId(id).ToList();
            }
            return productCategory;
        }

        public ProductCategory UpdateProductCategory(ProductCategory productCategory)
        {
            if (productCategory.Image != null)
            {
                //Delete existing image
                if (productCategory.ImageUrl != null)
                {
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductCategory");
                    DeleteFile(Path.Combine(directoryPath, productCategory.ImageUrl));
                }
                productCategory.ImageUrl = SaveProductImage(productCategory.Image);
            }
            //Remove all items under this category
            DeleteProductItems(productCategory.Id);
            //Add product item under this product category
            if (productCategory.AllItemIds.Count > 0)
            {
                var isAdded = AddProdItemsToCategory(productCategory.Id, productCategory.AllItemIds);
                if (!isAdded)
                {
                    return null;
                }
            }
            productCategory.LastModifiedOn = DateTime.UtcNow;
            context.ProductCategories.Update(productCategory);
            try
            {
                var isUpdated = context.SaveChanges() > 0;
                return isUpdated ? productCategory : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool DeleteFile(string relativePath)
        {
            try
            {
                var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductCategory");
                if (Directory.Exists(fileDirectory))
                {
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    File.Delete(filePath);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private string SaveProductImage(IFormFile imageFile)
        {
            var uniqueName = "ProductCategory_" + Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductCategory");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var filePath = Path.Combine(fileDirectory, uniqueName);
            try
            {
                //Save only path relative to wwwroot
                imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                return Path.Combine("ImageResources", "ProductCategory", uniqueName);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Remove all rows from ProductItemJoinProductCategory having specified productCategoryId
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        private bool DeleteProductItems(int productCategoryId)
        {
            //Remove all rows with product category id
            context.ProductItemJoinProductCategory.RemoveRange(
                    context.ProductItemJoinProductCategory.Where(j => j.ProductCategoryId == productCategoryId));
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private bool AddProdItemsToCategory(int productCategoryId, IEnumerable<int> prodItemIds)
        {
            //Add rows from the set
            foreach (var itemId in prodItemIds)
            {
                context.ProductItemJoinProductCategory.Add(new ProductItemJoinProductCategory
                {
                    ProductItemId = itemId,
                    ProductCategoryId = productCategoryId
                });
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private List<ProductItem> GetAllProdItemByProdCatgId(int catgId)
        {
            var query = from item in context.ProductItems
            join categoryitemmap in context.ProductItemJoinProductCategory
            on item.Id equals categoryitemmap.ProductItemId
            where categoryitemmap.ProductCategoryId == catgId
            select item;

            return query.ToList();
        }

    }
}
