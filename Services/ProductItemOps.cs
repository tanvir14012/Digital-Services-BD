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
    public class ProductItemOps : IProductItemOps
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductItemOps(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// Adds a productitem to database, saves the image to wwwroot/imageresource/productitem folder,
        /// stores the relative link to database column imageUrl
        /// </summary>
        /// <param name="productItem">the ProductItem model</param>
        /// <returns>returns added item if successful, otherwise returns null</returns>
        public ProductItem AddProductItem(ProductItem productItem)
        {
            if (productItem.Image != null)
            {
                productItem.ImageUrl = SaveProductImage(productItem.Image);
            }
            productItem.CreatedOn = DateTime.UtcNow;
            productItem.LastModifiedOn = DateTime.UtcNow;
            if(productItem.ProductItemFeature != null)
            {
                productItem.ProductItemFeature.CreatedOn = DateTime.UtcNow;
                productItem.ProductItemFeature.LastModifiedOn = DateTime.UtcNow;
            }
            //Add product item
            context.ProductItems.Add(productItem);
            try
            {
                var isSaved = context.SaveChanges() > 0;
                //After obtaining id, add entry to other tables like: price, category etc.
                //if(productItem.ProductItemPrice != null && productItem.ProductItemPrice.Count > 0)
                //{
                //    //productItem.ProductItemPrice is of type IList<> which is a reference type
                //    //The data referred is modified in the method, so in foreach it'll throw "Collection was modified, enumration operation .." error
                //    //ToList() will create a copy and pass it
                //    var isPriceAdded = AddProductPrice(productItem.Id, productItem.ProductItemPrice.ToList());
                //    if(! isPriceAdded)
                //    {
                //        return null;
                //    }
                //}
                if(productItem.CategoryIds != null && productItem.CategoryIds.Count() > 0)
                {
                    AddProdItemToCategories(productItem.Id, productItem.CategoryIds);
                }
                return isSaved ? productItem : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Delete productitem from database
        /// </summary>
        /// <param name="id">
        /// Id of ProductItem in database
        /// </param>
        /// <returns>
        /// returns deleted item if successful, otherwise returns null
        /// </returns>
        public ProductItem DeleteProductItem(int id)
        {
            var productItem = context.ProductItems.Find(id);
            if (productItem != null)
            {
                context.ProductItems.Remove(productItem);
            }
            try
            {
                if (context.SaveChanges() > 0)
                {
                    DeleteFile(productItem.ImageUrl);
                    return productItem;
                };
                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        /// <summary>
        /// Get all productitem
        /// </summary>
        /// <returns>returns a list of productitem</returns>
        public IEnumerable<ProductItem> GetAllProductItems()
        {
            return context.ProductItems.AsNoTracking().ToList();
        }
        /// <summary>
        /// Get productitem by id
        /// </summary>
        /// <param name="id">Id of productitem</param>
        /// <returns>returns null if not found </returns>
        public ProductItem GetProductItem(int id)
        {
            var productItem = context.ProductItems.Find(id);
            //Populate associated categories, prices, features for details view
            if (productItem != null)
            {
                productItem.Categories = GetProductItemCategories(id).ToList();
                productItem.ProductItemPrice = GetProductItemPrices(id).ToList();
                productItem.ProductItemFeature = GetProductItemFeature(id);
            }
            return productItem;
        }
        /// <summary>
        /// Updates a product item
        /// </summary>
        /// <param name="productItem"></param>
        /// <returns>updated product item, null if some error occurred</returns>
        public ProductItem UpdateProductItem(ProductItem productItem)
        {
            if (productItem.Image != null)
            {
                //Delete existing image
                if (productItem.ImageUrl != null)
                {
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductItem");
                    DeleteFile(Path.Combine(directoryPath, productItem.ImageUrl));
                }
                productItem.ImageUrl = SaveProductImage(productItem.Image);
            }
            //Delete all category entries for this product item
            RemoveAllCategoryEntriesByItemId(productItem.Id);
            //Add categories sent from ui
            if (productItem.CategoryIds != null && productItem.CategoryIds.Count > 0)
            {
                AddProdItemToCategories(productItem.Id, productItem.CategoryIds);
            }
            if(productItem.ProductItemFeature != null)
            {
                productItem.ProductItemFeature.LastModifiedOn = DateTime.UtcNow;
            }
            productItem.LastModifiedOn = DateTime.UtcNow;
            context.ProductItems.Update(productItem);
            try
            {
                var isUpdated = context.SaveChanges() > 0;
                return isUpdated ? productItem : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<ProductItem> GetAllProdItemByProdCatgId(int productCategoryId)
        {
            var query = from item in context.ProductItems
                        join categoryitemmap in context.ProductItemJoinProductCategory
                        on item.Id equals categoryitemmap.ProductItemId
                        where categoryitemmap.ProductCategoryId == productCategoryId
                        select item;

            return query.ToList();
        }

        private bool DeleteFile(string relativePath)
        {
            try
            {
                var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductItem");
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
            var uniqueName = "ProductItem_" + Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductItem");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var filePath = Path.Combine(fileDirectory, uniqueName);
            try
            {
                //Save only path relative to wwwroot
                imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                return Path.Combine("ImageResources", "ProductItem", uniqueName);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// Remove all rows from ProductItemPrices having specified productItemId
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        private bool DeleteProductPrices(int productItemId)
        {
            //Remove all rows with product item id
            context.ProductItemPrices.RemoveRange(
                    context.ProductItemPrices.Where(j => j.ProductItemId == productItemId).ToList());
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
        private IEnumerable<ProductItemPrice> GetProductItemPrices(int productItemId)
        {
            return context.ProductItemPrices.Where(p => p.ProductItemId == productItemId).ToList();
        }
        private IEnumerable<ProductCategory> GetProductItemCategories(int productItemId)
        {
            var query = from category in context.ProductCategories join
                        itemcategoryjoin in context.ProductItemJoinProductCategory
                        on category.Id equals itemcategoryjoin.ProductCategoryId
                        where itemcategoryjoin.ProductItemId == productItemId
                        select category;
            return query.ToList();
        }
        private ProductItemFeature GetProductItemFeature(int productItemId)
        {
            return context.ProductItemFeatures.Where(f => f.ProductItemId == productItemId).FirstOrDefault();
        }
        private bool AddProductPrice(int productItemId, IEnumerable<ProductItemPrice> prices)
        {
            foreach(var priceObj in prices)
            {
                context.ProductItemPrices.Add(new ProductItemPrice
                {
                    Price = priceObj.Price,
                    PriceCurrency = priceObj.PriceCurrency,
                    Discount = priceObj.Discount,
                    ProductItemId = productItemId,
                    CreatedOn = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Vat = priceObj.Vat
                });
            }
            
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool AddProdItemToCategories(int productItemId, IEnumerable<int> prodCategoryIds)
        {

            //Add rows from the set
            foreach (var catgId in prodCategoryIds)
            {
                    context.ProductItemJoinProductCategory.Add(new ProductItemJoinProductCategory
                    {
                        ProductCategoryId = catgId,
                        ProductItemId = productItemId
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

        private void RemoveAllCategoryEntriesByItemId(int productItemId)
        {
            context.ProductItemJoinProductCategory.RemoveRange(
                context.ProductItemJoinProductCategory.Where(j => j.ProductItemId == productItemId));
            try
            {
                context.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public ProductItemViewModel ConvertModelToViewModel(ProductItem model)
        {
            var productFeature = new ProductItemFeatureViewModel
            {
                Company = model.ProductItemFeature?.Company,
                CreatedOn = model.ProductItemFeature.CreatedOn,
                DeliveryInfo = model.ProductItemFeature?.DeliveryInfo,
                Description = model.ProductItemFeature?.Description,
                Developer = model.ProductItemFeature?.Developer,
                DownloadSize = model.ProductItemFeature?.DownloadSize,
                Genre = model.ProductItemFeature?.Genre.Split(",").ToList(),
                Id = model.ProductItemFeature.Id,
                LastModifiedOn = model.ProductItemFeature.LastModifiedOn,
                Os = model.ProductItemFeature?.Os.Split(",").ToList(),
                Platform = model.ProductItemFeature?.Platform.Split(",").ToList(),
                ProductItemId = model.ProductItemFeature.ProductItemId,
                Publisher = model.ProductItemFeature?.Publisher,
                RegionCodes = model.ProductItemFeature?.RegionCodes.Split(",").ToList(),
                RegionCountries = model.ProductItemFeature?.RegionCountries.Split(",").ToList(),
                ReleaseDate = model.ProductItemFeature.ReleaseDate,
                RequirementCpu = model.ProductItemFeature?.RequirementCpu,
                RequirementDisk = model.ProductItemFeature?.RequirementDisk,
                RequirementGpu = model.ProductItemFeature?.RequirementGpu,
                RequirementRam = model.ProductItemFeature?.RequirementRam,
                ValidityPeriod = model.ProductItemFeature?.ValidityPeriod
            };

            var productItemViewModel = new ProductItemViewModel
            {
                ProductItemFeature = productFeature,
                Categories = model.Categories,
                CategoryIds = model.CategoryIds,
                CreatedOn = model.CreatedOn,
                HowToConsume = model.HowToConsume,
                Id = model.Id,
                Image = model.Image,
                ImageUrl = model.ImageUrl,
                IsActive = model.IsActive,
                IsShippable = model.IsShippable,
                LastModifiedOn = model.LastModifiedOn,
                Limitations = model.Limitations,
                Name = model.Name,
                Overview = model.Overview,
                ProductItemJoinProductCategory = model.ProductItemJoinProductCategory,
                ProductItemJoinPromoOffer = model.ProductItemJoinPromoOffer,
                ProductItemJoinSearchTagProductItem = model.ProductItemJoinSearchTagProductItem,
                ProductItemPrice = model.ProductItemPrice,
                WhatCanBeDone = model.WhatCanBeDone
            };
            return productItemViewModel;
        }

        public ProductItem ConvertViewModelToModel(ProductItemViewModel model)
        {
            var productFeature = new ProductItemFeature
            {
                Company = model.ProductItemFeature?.Company,
                CreatedOn = model.ProductItemFeature.CreatedOn,
                DeliveryInfo = model.ProductItemFeature?.DeliveryInfo,
                Description = model.ProductItemFeature?.Description,
                Developer = model.ProductItemFeature?.Developer,
                DownloadSize = model.ProductItemFeature?.DownloadSize,
                Genre = string.Join(",", model.ProductItemFeature?.Genre.Select(g => g.ToString())),
                Id = model.ProductItemFeature.Id,
                LastModifiedOn = model.ProductItemFeature.LastModifiedOn,
                Os = string.Join(",", model.ProductItemFeature?.Os.Select(g => g.ToString())),
                Platform = string.Join(",", model.ProductItemFeature?.Platform.Select(g => g.ToString())),
                ProductItemId = model.ProductItemFeature.ProductItemId,
                Publisher = model.ProductItemFeature?.Publisher,
                RegionCodes = string.Join(",", model.ProductItemFeature?.RegionCodes.Select(g => g.ToString())),
                RegionCountries = string.Join(",", model.ProductItemFeature?.RegionCountries.Select(g => g.ToString())),
                ReleaseDate = model.ProductItemFeature.ReleaseDate,
                RequirementCpu = model.ProductItemFeature?.RequirementCpu,
                RequirementDisk = model.ProductItemFeature?.RequirementDisk,
                RequirementGpu = model.ProductItemFeature?.RequirementGpu,
                RequirementRam = model.ProductItemFeature?.RequirementRam,
                ValidityPeriod = model.ProductItemFeature?.ValidityPeriod
            };
            var productItem = new ProductItem
            {
                ProductItemFeature = productFeature,
                Categories = model.Categories,
                CategoryIds = model.CategoryIds,
                CreatedOn = model.CreatedOn,
                HowToConsume = model.HowToConsume,
                Id = model.Id,
                Image = model.Image,
                ImageUrl = model.ImageUrl,
                IsActive = model.IsActive,
                IsShippable = model.IsShippable,
                LastModifiedOn = model.LastModifiedOn,
                Limitations = model.Limitations,
                Name = model.Name,
                Overview = model.Overview,
                ProductItemJoinProductCategory = model.ProductItemJoinProductCategory,
                ProductItemJoinPromoOffer = model.ProductItemJoinPromoOffer,
                ProductItemJoinSearchTagProductItem = model.ProductItemJoinSearchTagProductItem,
                ProductItemPrice = model.ProductItemPrice,
                WhatCanBeDone = model.WhatCanBeDone
            };
            return productItem;
        }
    }
}
