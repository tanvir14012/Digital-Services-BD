using Digital_Services_BD.Models;
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
        ICollection<ProductCategory> GetAllProdCategoriesByProdGroupId(int productGroupId);
    }
}
