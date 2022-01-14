using Digital_Services_BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class ProductSectionOps : IProductSectionOps
    {
        private readonly AppDbContext context;

        public ProductSectionOps(AppDbContext context)
        {
            this.context = context;
        }
        public ProductSection AddProductSection(ProductSection productSection)
        {
            productSection.CreatedOn = DateTime.UtcNow;
            productSection.LastModifiedOn = DateTime.UtcNow;
            context.ProductSections.Add(productSection);
            try
            {
                var isSaved = context.SaveChanges() > 0;
                //Add product item under this product group
                if (productSection.ProductItemIds.Count > 0)
                {
                    var isAdded = AddProdItemsToSection(productSection.Id, productSection.ProductItemIds);
                    if (!isAdded)
                    {
                        return null;
                    }
                }
                return isSaved ? productSection : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProductSection DeleteProductSection(int productSectionId)
        {
            var productSection = context.ProductSections.Find(productSectionId);
            if (productSection != null)
            {
                context.ProductSections.Remove(productSection);
            }
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return productSection;
                };
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProductSection UpdateProductSection(ProductSection productSection)
        {
            //Remove all section entries from join table
            DeleteProductSections(productSection.Id);
            //Add product item list under this product section sent from ui
            if (productSection.ProductItemIds.Count > 0)
            {
                var isAdded = AddProdItemsToSection(productSection.Id, productSection.ProductItemIds);
                if (!isAdded)
                {
                    return null;
                }
            }
            productSection.LastModifiedOn = DateTime.UtcNow;
            context.ProductSections.Update(productSection);
            try
            {
                var isUpdated = context.SaveChanges() > 0;
                return isUpdated ? productSection : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<ProductSection> GetAllProductSections()
        {
            return context.ProductSections.AsNoTracking().ToList().OrderBy(s => s.Rank);
        }

        public async Task<ICollection<ProductSection>> GetAllProductSectionsWithNavigation()
        {
            return await context.ProductSections.AsNoTracking()
                    .Include(ps => ps.ProductSectionJoinProductItem)
                        .ThenInclude(join => join.ProductItem)
                            .ThenInclude(item => item.ProductItemPrice)
                        .Include(ps => ps.ProductSectionJoinProductItem)
                            .ThenInclude(join => join.ProductItem)
                                .ThenInclude(item => item.ProductStockCount)
                    .OrderBy(ps => ps.Rank)
                    .ToListAsync();
        }

        public ProductSection GetProductSection(int productSectionId)
        {
            var productSection = context.ProductSections.Find(productSectionId);
            //Populate associated items for details view
            if (productSection != null)
            {
                productSection.ProductItems = GetAllProdItemsByProdSectionId(productSectionId).ToList();
            }
            return productSection;
        }

        private bool AddProdItemsToSection(int productSectionId, IEnumerable<int> ProdItemIds)
        {
            //Add rows from the set
            foreach (var itemId in ProdItemIds)
            {
                context.ProductSectionJoinProductItem.Add(new ProductSectionJoinProductItem
                {
                    ProductItemId = itemId,
                    ProductSectionId = productSectionId
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
        public IEnumerable<ProductItem> GetAllProdItemsByProdSectionId(int productSectionId)
        {
            var query = from item in context.ProductItems
                        join itemsectionmap in context.ProductSectionJoinProductItem
                        on item.Id equals itemsectionmap.ProductItemId
                        where itemsectionmap.ProductSectionId == productSectionId
                        select item;
            return query.ToList();
        }

        private bool DeleteProductSections(int productSectionId)
        {
            //Remove all rows with product section id
            context.ProductSectionJoinProductItem.RemoveRange(
                    context.ProductSectionJoinProductItem.Where(j => j.ProductSectionId == productSectionId));
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

        public IEnumerable<int> GetAvailableRanks()
        {
            var ranks = new List<int>();
            for(var i = 0; i <= context.ProductSections.Count(); i++)
            {
                ranks.Add(i + 1);
            }
            ranks = ranks.Except(context.ProductSections.Select(s => s.Rank).ToList()).ToList();
            return ranks;
        }

    }
}
