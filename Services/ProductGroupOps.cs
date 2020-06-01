using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class ProductGroupOps : IProductGroupOps
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductGroupOps(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// Adds a productgroup to database, saves the image to wwwroot/imageresource/productgroup folder,
        /// stores the relative link to database column imageUrl
        /// </summary>
        /// <param name="productGroup">the ProductGroup model</param>
        /// <returns>returns added item if successful, otherwise returns null</returns>
        public ProductGroup AddProductGroup(ProductGroup productGroup)
        {
            if(productGroup.Image != null)
            {
                productGroup.ImageUrl = SaveProductImage(productGroup.Image);
            }
            //Add product category under this product group
            if (productGroup.AllCategoryIds.Count > 0)
            {
                var isAdded = AddProdCategoriesToGroup(productGroup.Id, productGroup.AllCategoryIds);
                if (!isAdded)
                {
                    return null;
                }
            }
            context.ProductGroups.Add(productGroup);
            try
            {
                var isSaved = context.SaveChanges() > 0;
                return isSaved ? productGroup : null;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Delete productgroup from database
        /// </summary>
        /// <param name="id">
        /// Id of ProductGroup in database
        /// </param>
        /// <returns>
        /// returns deleted item if successful, otherwise returns null
        /// </returns>
        public ProductGroup DeleteProductGroup(int id)
        {
            var productGroup = context.ProductGroups.Find(id);
            if(productGroup != null)
            {
                context.ProductGroups.Remove(productGroup);
            }
            try
            {
                if (context.SaveChanges() > 0)
                {
                    DeleteFile(productGroup.ImageUrl);
                    return productGroup;
                };
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        /// <summary>
        /// Get all productgroup
        /// </summary>
        /// <returns>returns a list of productgroup</returns>
        public IEnumerable<ProductGroup> GetAllProductGroups()
        {
            return context.ProductGroups.AsNoTracking().ToList();
        }
        /// <summary>
        /// Get productgroup by id
        /// </summary>
        /// <param name="id">Id of productgroup</param>
        /// <returns>returns null if not found </returns>
        public ProductGroup GetProductGroup(int id)
        {
            var productGroup = context.ProductGroups.Find(id);
            //Populate associated categories for details view
            if(productGroup != null)
            {
                productGroup.AllCategories = GetAllProdCategoriesByProdGroupId(id);
            }
            return productGroup;
        }
        /// <summary>
        /// Updates a product group
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns>updated product group, null if some error occurred</returns>
        public ProductGroup UpdateProductGroup(ProductGroup productGroup)
        {
            if (productGroup.Image != null)
            {
                //Delete existing image
                if(productGroup.ImageUrl != null)
                {
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductGroup");
                    DeleteFile(Path.Combine(directoryPath, productGroup.ImageUrl));
                }
                productGroup.ImageUrl = SaveProductImage(productGroup.Image);
            }
            //Update product category under this product group
            if(productGroup.AllCategoryIds.Count > 0)
            {
                var isAdded = AddProdCategoriesToGroup(productGroup.Id, productGroup.AllCategoryIds);
                if(! isAdded)
                {
                    return null;
                }
            }
            productGroup.LastModifiedOn = DateTime.UtcNow;
            context.ProductGroups.Update(productGroup);
            try
            {
                var isUpdated = context.SaveChanges() > 0;
                return isUpdated ? productGroup : null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public ICollection<ProductCategory> GetAllProdCategoriesByProdGroupId(int productGroupId)
        {
            var query = from category in context.ProductCategories
                        join categorygroupmap in context.productCategoryJoinProductGroup
                        on category.Id equals categorygroupmap.ProductCategoryId
                        select category;

            return query.ToList();
        }

        private bool DeleteFile(string relativePath)
        {
            try
            {
                var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductGroup");
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
            var uniqueName = "ProductGroup_" + Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductGroup");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var filePath = Path.Combine(fileDirectory, uniqueName);
            try
            {
                //Save only path relative to wwwroot
                imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                return Path.Combine("ImageResources", "ProductGroup", uniqueName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool AddProdCategoriesToGroup(int productGroupId, IEnumerable<int> ProdCategoryIds)
        {
            //Remove all rows with product group id
            context.productCategoryJoinProductGroup.RemoveRange(
                    context.productCategoryJoinProductGroup.Where(j => j.ProductGroupId == productGroupId).ToList());
            //Add rows from the set
            foreach (var catId in ProdCategoryIds)
            {
                context.productCategoryJoinProductGroup.Add(new ProductCategoryJoinProductGroup
                {
                    ProductGroupId = productGroupId,
                    ProductCategoryId = catId
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

        private bool DeleteProductCategories(int productGroupId)
        {
            //Remove all rows with product group id
            context.productCategoryJoinProductGroup.RemoveRange(
                    context.productCategoryJoinProductGroup.Where(j => j.ProductGroupId == productGroupId).ToList());
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
    }
}
