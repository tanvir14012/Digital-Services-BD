using Digital_Services_BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class ProductItemBundleOps : IProductItemBundleOps
    {
        private readonly AppDbContext context;

        public ProductItemBundleOps(AppDbContext context)
        {
            this.context = context;
        }
        public ProductItemBundle AddProductItemBundle(ProductItemBundle model)
        {
            model.CreatedOn = DateTime.UtcNow;
            context.ProductItemBundles.Add(model);
            try
            {
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return null;
            }
            
            return model;
        }

        public ProductItemBundle DeleteProductItemBundle(int ProductItemBundleId)
        {
            try
            {
                var bundle = new ProductItemBundle { Id = ProductItemBundleId };
                context.ProductItemBundles.Remove(bundle);
                var deleted = context.SaveChanges() > 0;
                return deleted ? bundle: null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ProductItemBundle> GetAllProductItemBundles()
        {
            return context.ProductItemBundles.AsNoTracking().Include(bundle => bundle.ProductItemBundleJoinProductItem)
                        .ThenInclude(bundleItem => bundleItem.ProductItem)
                        .ThenInclude(product => product.ProductItemPrice)
                        .ToList();
        }

        public async Task<IEnumerable<ProductItemBundle>> GetAllProductItemBundlesAsync()
        {
            return await context.ProductItemBundles.Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                .ThenInclude(product => product.ProductItemPrice)
                        .Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                  .ThenInclude(product => product.ProductStockCount)
                        .Where(bundle => bundle.IsActiveNow)
                        .ToListAsync();
        }


        public async Task<IEnumerable<ProductItemBundle>> GetAllProductItemBundlesAsync(int productItemId)
        {
            return await context.ProductItemBundles.Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                .ThenInclude(product => product.ProductItemPrice)
                        .Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                  .ThenInclude(product => product.ProductStockCount)
                        .Where(bundle => bundle.IsActiveNow && bundle.ProductItemBundleJoinProductItem.Any(join => join.ProductItemId == productItemId))
                        .ToListAsync();
        }

        public ProductItemBundle GetProductItemBundle(int ProductItemBundleId)
        {
            return context.ProductItemBundles.Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                .ThenInclude(product => product.ProductItemPrice)
                            .FirstOrDefault(bundle => bundle.Id == ProductItemBundleId);
        }

        public async Task<ProductItemBundle> GetProductItemBundleAsync(int ProductItemBundleId)
        {
            return await context.ProductItemBundles.Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                .ThenInclude(product => product.ProductItemPrice)
                        .Include(bundle => bundle.ProductItemBundleJoinProductItem)
                            .ThenInclude(bundleItem => bundleItem.ProductItem)
                                  .ThenInclude(product => product.ProductStockCount)
                        .FirstOrDefaultAsync(bundle => bundle.Id == ProductItemBundleId);
        }

        public ProductItemBundle UpdateProductItemBundle(ProductItemBundle model)
        {
            ProductItemBundle bundle;
            try
            {
                bundle = context.ProductItemBundles
                .Include(bndl => bndl.ProductItemBundleJoinProductItem)
                .FirstOrDefault(bndl => bndl.Id == model.Id);
                if(bundle != null)
                {
                    bundle.ProductItemBundleJoinProductItem.Clear();
                    bundle.Name = model.Name;
                    bundle.IsActiveNow = model.IsActiveNow;
                    bundle.CreatedOn = model.CreatedOn;
                    bundle.BundleDiscount = model.BundleDiscount;
                    bundle.ProductItemBundleJoinProductItem = model.ProductItemBundleJoinProductItem;

                    context.SaveChanges();
                }   
            }
            catch (Exception ex)
            {
                return null;
            }

            return bundle;
        }
    }
}
