using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (productGroup.Image != null)
            {
                productGroup.ImageUrl = SaveProductImage(productGroup.Image);
            }
            productGroup.CreatedOn = DateTime.UtcNow;
            productGroup.LastModifiedOn = DateTime.UtcNow;
            context.ProductGroups.Add(productGroup);
            try
            {
                var isSaved = context.SaveChanges() > 0;
                //Add product category under this product group
                if (productGroup.AllCategoryIds.Count > 0)
                {
                    var isAdded = AddProdCategoriesToGroup(productGroup.Id, productGroup.AllCategoryIds);
                    if (!isAdded)
                    {
                        return null;
                    }
                }
                return isSaved ? productGroup : null;
            }
            catch (Exception e)
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
            if (productGroup != null)
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
            catch (Exception e)
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
            if (productGroup != null)
            {
                productGroup.AllCategories = GetAllProdCategoriesByProdGroupId(id).ToList();
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
                if (productGroup.ImageUrl != null)
                {
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "ProductGroup");
                    DeleteFile(Path.Combine(directoryPath, productGroup.ImageUrl));
                }
                productGroup.ImageUrl = SaveProductImage(productGroup.Image);
            }
            //Remove all category entries
            DeleteProductCategories(productGroup.Id);
            //Add product category list under this product group sent from ui
            if (productGroup.AllCategoryIds.Count > 0)
            {
                var isAdded = AddProdCategoriesToGroup(productGroup.Id, productGroup.AllCategoryIds);
                if (!isAdded)
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
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<ProductCategory> GetAllProdCategoriesByProdGroupId(int productGroupId)
        {
            var query = from category in context.ProductCategories
                        join categorygroupmap in context.ProductCategoryJoinProductGroup
                        on category.Id equals categorygroupmap.ProductCategoryId
                        where categorygroupmap.ProductGroupId == productGroupId
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
            //Add rows from the set
            foreach (var catId in ProdCategoryIds)
            {
                context.ProductCategoryJoinProductGroup.Add(new ProductCategoryJoinProductGroup
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
        /// <summary>
        /// Remove all rows from ProductCategoryJoinProductGroup having specified productGroupId
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        private bool DeleteProductCategories(int productGroupId)
        {
            //Remove all rows with product group id
            context.ProductCategoryJoinProductGroup.RemoveRange(
                    context.ProductCategoryJoinProductGroup.Where(j => j.ProductGroupId == productGroupId));
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
        /// <summary>
        /// Filters categories of a product group 
        /// </summary>
        /// <param name="productGroupId"></param>
        /// <param name="pageNo"></param>
        /// <param name="sortBy"></param>
        /// <param name="priceRange"></param>
        /// <returns></returns>
        public FilteredCategories FilterCategories(int productGroupId, int pageNo, string sortBy, string priceRange)
        {
            var query = from category in context.ProductCategories
                        join categorygroupmap in context.ProductCategoryJoinProductGroup
                        on category.Id equals categorygroupmap.ProductCategoryId
                        where categorygroupmap.ProductGroupId == productGroupId
                        join categoryitemmap in context.ProductItemJoinProductCategory
                        on category.Id equals categoryitemmap.ProductCategoryId
                        join item in context.ProductItems
                        on categoryitemmap.ProductItemId equals item.Id
                        join prices in context.ProductItemPrices
                        on item.Id equals prices.ProductItemId
                        where prices.PriceCurrency == "BDT"
                        select new { category, item, prices };
            var joinTable = query.Distinct().ToList();
            if (priceRange != null && Regex.IsMatch(priceRange, @"^\d+to\d+$"))
            {
                decimal minPrice = Convert.ToDecimal(priceRange.Split("to")[0]);
                decimal maxPrice = Convert.ToDecimal(priceRange.Split("to")[1]);
                joinTable = joinTable.GroupBy(jt => jt.category.Id).Select(g => 
                new {
                    category = new ProductCategory
                    {
                        Id = g.Key,
                        Name = g.First().category.Name,
                        Overview = g.First().category.Overview,
                        AllItemIds = g.First().category.AllItemIds,
                        AllItems = g.First().category.AllItems,
                        HowToConsume = g.First().category.HowToConsume,
                        Image = g.First().category.Image,
                        ImageUrl = g.First().category.ImageUrl,
                        LastModifiedOn = g.First().category.LastModifiedOn,
                        CreatedOn = g.First().category.CreatedOn,
                        Limitations = g.First().category.Limitations,
                        WhatCanBeDone = g.First().category.WhatCanBeDone,
                        ProductCategoryJoinProductGroup = g.First().category.ProductCategoryJoinProductGroup,
                        ProductItemJoinProductCategory = g.First().category.ProductItemJoinProductCategory
                    },
                    item = new ProductItem
                    {
                        Id = g.First().item.Id,
                        Categories = g.First().item.Categories,
                        ProductItemJoinProductCategory = g.First().item.ProductItemJoinProductCategory,
                        WhatCanBeDone = g.First().item.WhatCanBeDone,
                        Limitations = g.First().item.Limitations,
                        CreatedOn = g.First().item.CreatedOn,
                        LastModifiedOn = g.First().item.LastModifiedOn,
                        ImageUrl = g.First().item.ImageUrl,
                        Image = g.First().item.Image,
                        CategoryIds = g.First().item.CategoryIds,
                        HowToConsume = g.First().item.HowToConsume,
                        IsActive = g.First().item.IsActive,
                        IsShippable = g.First().item.IsShippable,
                        Name = g.First().item.Name,
                        Overview = g.First().item.Overview,
                        ProductItemBundleJoinProductItem = g.First().item.ProductItemBundleJoinProductItem,
                        ProductItemFeature = g.First().item.ProductItemFeature,
                        ProductItemJoinPromoOffer = g.First().item.ProductItemJoinPromoOffer,
                        ProductItemJoinSearchTagProductItem = g.First().item.ProductItemJoinSearchTagProductItem,
                        ProductItemPrice = g.First().item.ProductItemPrice,
                        ProductSectionJoinProductItem = g.First().item.ProductSectionJoinProductItem
                    },
                    prices = new ProductItemPrice
                    {
                        Id = g.First().prices.Id,
                        Price = g.First().prices.Price,
                        CreatedOn = g.First().prices.CreatedOn,
                        Discount = g.First().prices.Discount,
                        LastModifiedOn = g.First().prices.LastModifiedOn,
                        PriceCurrency = g.First().prices.PriceCurrency,
                        ProductItem = g.First().prices.ProductItem,
                        ProductItemId = g.First().prices.ProductItemId,
                        Vat = g.First().prices.Vat
                    }
                }).Where(jt => (jt.prices.Price - jt.prices.Discount) >= minPrice 
                    && (jt.prices.Price - jt.prices.Discount) <= maxPrice).ToList();
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "name": joinTable = joinTable.OrderBy(jt => jt.category.Name).ToList();
                        break;
                    case "p_l_h": joinTable = joinTable.OrderBy(jt => (jt.prices.Price - jt.prices.Discount)).ToList();
                        break;
                    case "p_h_l": joinTable = joinTable.OrderByDescending(jt => (jt.prices.Price - jt.prices.Discount)).ToList(); 
                        break;
                    default:
                        break;
                }
            }
            var categories = joinTable.Select(jt => jt.category).Distinct().ToList();
            var totalCategories = categories.Count();

            if(pageNo >= 0 && pageNo < categories.Count)
            {
                var start = pageNo * ProductConfig.NoOfProductCategoryPerPage;
                try
                {
                    categories = categories.GetRange(start, ProductConfig.NoOfProductCategoryPerPage);
                }
                catch(ArgumentException e)
                {
                    if(start > categories.Count)
                    {
                        categories = categories.TakeLast(ProductConfig.NoOfProductCategoryPerPage).ToList();
                    }
                    else if(start + ProductConfig.NoOfProductCategoryPerPage >= categories.Count )
                    {
                        categories = categories.GetRange(start, categories.Count() - start);
                    }
                }
                
            }
            var filteredCategories = new FilteredCategories
            {
                TotalCategories = totalCategories,
                CategoriesUnderFilter = categories
            };

            return filteredCategories;
        }

        public async Task<ICollection<ProductGroup>> GetProductGroupsWithNavigation()
        {
            return await context.ProductGroups.AsNoTracking()
                    .Include(pg => pg.ProductCategoryJoinProductGroup)
                        .ThenInclude(join => join.ProductCategory)
                        .ThenInclude(pc => pc.ProductItemJoinProductCategory)
                        .ThenInclude(join => join.ProductItem)
                    .Select(pg => new ProductGroup 
                    { 
                        Id = pg.Id, 
                        Name = pg.Name,
                        AllCategories = pg.ProductCategoryJoinProductGroup.Select(join => new ProductCategory
                        { 
                            Id = join.ProductCategory.Id,
                            Name = join.ProductCategory.Name,
                            AllItems = join.ProductCategory.ProductItemJoinProductCategory.Select(join2 => new ProductItem
                            {
                                Id = join2.ProductItem.Id,
                                Name = join2.ProductItem.Name
                            }).ToList()
                        }).ToList()
                    }).ToListAsync();
        }

        public async Task<ICollection<ProductGroup>> GetAllProductGroupsIdName()
        {
            return await context.ProductGroups.AsNoTracking()
                   .Select(pg => new ProductGroup
                   {
                       Id = pg.Id,
                       Name = pg.Name,
                   }).ToListAsync();
        }
    }
}
