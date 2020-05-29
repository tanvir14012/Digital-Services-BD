using Digital_Services_BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class ProductGroupOps : IProductGroupOps
    {
        private readonly AppDbContext context;

        public ProductGroupOps(AppDbContext context)
        {
            this.context = context;
        }
        public ProductGroup AddProductGroup(ProductGroup productGroup)
        {
            context.ProductGroups.Add(productGroup);
            context.SaveChanges();
            return productGroup;
        }

        public ProductGroup DeleteProductGroup(int id)
        {
            var productGroup = context.ProductGroups.Find(id);
            if(productGroup != null)
            {
                context.ProductGroups.Remove(productGroup);
            }
            context.SaveChanges();
            return productGroup;
        }

        public IEnumerable<ProductGroup> GetAllProductGroups()
        {
            return context.ProductGroups.AsNoTracking().ToList();
        }

        public ProductGroup GetProductGroup(int id)
        {
            return context.ProductGroups.Find(id); ;
        }

        public ProductGroup UpdateProductGroup(ProductGroup productGroup)
        {
            context.ProductGroups.Update(productGroup);
            context.SaveChanges();
            return productGroup;
        }
    }
}
