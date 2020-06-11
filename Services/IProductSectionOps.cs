using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductSectionOps
    {
        ProductSection AddProductSection(ProductSection model);
        IEnumerable<ProductSection> GetAllProductSections();
        ProductSection GetProductSection(int productSectionId);
        ProductSection UpdateProductSection(ProductSection model);
        ProductSection DeleteProductSection(int productSectionId);
        IEnumerable<ProductItem> GetAllProdItemsByProdSectionId(int productSectionId);
        IEnumerable<int> GetAvailableRanks();
    }
}
