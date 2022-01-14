using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductItemBundleOps
    {
        ProductItemBundle AddProductItemBundle(ProductItemBundle model);
        IEnumerable<ProductItemBundle> GetAllProductItemBundles();
        Task<IEnumerable<ProductItemBundle>> GetAllProductItemBundlesAsync();
        Task<IEnumerable<ProductItemBundle>> GetAllProductItemBundlesAsync(int productItemId);
        ProductItemBundle GetProductItemBundle(int ProductItemBundleId);
        Task<ProductItemBundle> GetProductItemBundleAsync(int ProductItemBundleId);
        ProductItemBundle UpdateProductItemBundle(ProductItemBundle model);
        ProductItemBundle DeleteProductItemBundle(int ProductItemBundleId);
    }
}
