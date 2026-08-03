using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace Digital_Services_BD.Services
{
    public class ProductStockOps : IProductStockOps
    {
        private readonly AppDbContext context;
        private readonly IDataProtector dataProtector;

        public ProductStockOps(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
        }
        public async Task<ProductStock> AddProductStock(ProductStock productStock)
        {
            try
            {
                productStock.CreateTime = DateTime.UtcNow;
                productStock.LastUpdateTime = DateTime.UtcNow;

                await context.ProductStocks.AddAsync(productStock);
                await context.SaveChangesAsync();
                return productStock;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductStock> DeleteProductStock(int productStockId)
        {
            var ps = await context.ProductStocks.FindAsync(productStockId);
            if (ps != null)
            {
                context.ProductStocks.Remove(ps);

                try
                {
                    await context.SaveChangesAsync();
                    return ps;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<FilteredProductStocks> FilterProductStocks(int groupId, int categoryId,
            int productId, int pageNo = 1, int ProductStockPerPage = 5, string sortBy = "date_desc")
        {
            var productStocks = context.ProductStocks.AsNoTracking()
               .Include(ps => ps.ProductItem)
                    .ThenInclude(item => item.ProductItemJoinProductCategory)
                        .ThenInclude(join => join.ProductCategory)
                            .ThenInclude(ctg => ctg.ProductCategoryJoinProductGroup).AsQueryable();

            if (groupId != -1)
            {
                productStocks = productStocks.Where(ps => ps.ProductItem.ProductItemJoinProductCategory
                    .Any(join => join.ProductCategory.ProductCategoryJoinProductGroup.Any(join => join.ProductGroupId == groupId))).AsQueryable();
            }

            if (categoryId != -1)
            {
                productStocks = productStocks.Where(ps => ps.ProductItem.ProductItemJoinProductCategory
                   .Any(join => join.ProductCategoryId == categoryId)).AsQueryable();
            }

            if (productId != -1)
            {
                productStocks = productStocks.Where(ps => ps.ProductItem.Id == productId).AsQueryable();
            }

            switch (sortBy)
            {
                case "name":
                    productStocks = productStocks.OrderBy(ps => ps.ProductItem.Name);
                    break;
                case "date_desc":
                    productStocks = productStocks.OrderByDescending(ps => ps.CreateTime);
                    break;
                case "date_asc":
                    productStocks = productStocks.OrderBy(ps => ps.CreateTime);
                    break;
                case "active":
                    productStocks = productStocks.Where(ps => ps.Status == ProductStockStatus.ACTIVE).AsQueryable();
                    break;
                case "halted":
                    productStocks = productStocks.Where(ps => ps.Status == ProductStockStatus.HALTED).AsQueryable(); ;
                    break;
                case "delivered":
                    productStocks = productStocks.Where(ps => ps.Status == ProductStockStatus.DELIVERED).AsQueryable(); ;
                    break;
                case "invalid":
                    productStocks = productStocks.Where(ps => ps.Status == ProductStockStatus.INVALID).AsQueryable(); ;
                    break;
            }

            return new FilteredProductStocks
            {
                TotalProductStocks = await productStocks.CountAsync(),
                ProductStocksUnderFilter = await productStocks.Skip((pageNo - 1) * ProductStockPerPage)
                .Take(ProductStockPerPage)
                .ToListAsync(),
                PageNo = pageNo,
                ProductStockPerPage = ProductStockPerPage,
                SortBy = sortBy,
                GroupId = groupId,
                CategoryId = categoryId,
                ProductId = productId
            };
        }

        public async Task<IEnumerable<ProductStock>> GetAllProductStocks(int pageNo = 1, int itemPerPage = 10)
        {
            var productStocks = await context.ProductStocks.AsNoTracking()
                .Include(ps => ps.ProductItem)
                .OrderByDescending(ps => ps.CreateTime)
                .Skip((pageNo - 1) * itemPerPage)
                .Take(itemPerPage)
                .ToListAsync();

            return productStocks;
        }

        public async Task<ProductStock> GetProductStock(int productStockId)
        {
            var productStock = await context.ProductStocks.AsNoTracking()
                .Include(ps => ps.ProductItem)
                .Where(ps => ps.Id == productStockId)
                .FirstOrDefaultAsync();

            return productStock;
        }

        public async Task<int> GetProductStockCount()
        {
            var count = await context.ProductStocks
                .AsNoTracking().CountAsync();
            return count;
        }

        public async Task<string> GetProductHierarchy()
        {
            var products = context.ProductGroups
                    .Include(grp => grp.ProductCategoryJoinProductGroup)
                        .ThenInclude(join => join.ProductCategory)
                            .ThenInclude(ctg => ctg.ProductItemJoinProductCategory)
                                .ThenInclude(join => join.ProductItem)
                    .AsQueryable();

            var productHierarchy = await products.Select(grp => new
            {
                productGroupId = grp.Id,
                productGroupName = grp.Name,
                categories = grp.ProductCategoryJoinProductGroup.Select(join => new
                {
                    id = join.ProductCategoryId,
                    name = join.ProductCategory.Name,
                    products = join.ProductCategory.ProductItemJoinProductCategory.Select(join => new
                    {
                        id = join.ProductItemId,
                        name = join.ProductItem.Name
                    }).ToList()
                }).ToList()
            }).ToListAsync();

            return JsonConvert.SerializeObject(productHierarchy);
        }

        public async Task<ProductStock> UpdateProductStock(ProductStock productStock)
        {
            try
            {
                var model = await context.ProductStocks.FindAsync(productStock.Id);
                model.LastUpdateTime = DateTime.UtcNow;
                model.MainCode = productStock.MainCode;
                model.AuxiliaryCode = productStock.AuxiliaryCode;
                model.OptionA = productStock.OptionA;
                model.OptionB = productStock.OptionB;
                model.OptionC = productStock.OptionC;
                model.Remark = productStock.Remark;
                model.VendorInfo = productStock.VendorInfo;
                model.ProductItemId = productStock.ProductItemId;
                model.Status = productStock.Status;

                await context.SaveChangesAsync();
                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}
