using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductItemOps
    {
        IEnumerable<ProductItem> GetAllProductItems();
        ProductItem GetProductItem(int id);
        Task<ProductItem> GetProductItemAsync(int id);
        ProductItem AddProductItem(ProductItem ProductItem);
        ProductItem DeleteProductItem(int id);
        ProductItem UpdateProductItem(ProductItem ProductItem);
        IEnumerable<ProductItem> GetAllProdItemByProdCatgId(int productItemId);
        ProductItemViewModel ConvertModelToViewModel(ProductItem model);
        ProductItem ConvertViewModelToModel(ProductItemViewModel model);
    }
}
