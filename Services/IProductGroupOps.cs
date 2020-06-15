using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductGroupOps
    {
        IEnumerable<ProductGroup> GetAllProductGroups();
        ProductGroup GetProductGroup(int id);
        ProductGroup AddProductGroup(ProductGroup productGroup);
        ProductGroup DeleteProductGroup(int id);
        ProductGroup UpdateProductGroup(ProductGroup productGroup);
        IEnumerable<ProductCategory> GetAllProdCategoriesByProdGroupId(int productGroupId);
        FilteredCategories FilterCategories(int productGroupId, int pageNo, string sortBy, string priceRange);
    }
}
