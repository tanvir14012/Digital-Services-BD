using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductCategoryOps
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
        ProductCategory GetProductCategory(int id);
        Task<ProductCategory> GetProductCategoryAsync(int id);
        ProductCategory AddProductCategory(ProductCategory ProductCategory);
        ProductCategory DeleteProductCategory(int id);
        ProductCategory UpdateProductCategory(ProductCategory ProductCategory);
        IEnumerable<ProductCategory> GetAllProdCategoryByProdItemId(int productItemId);
        decimal GetMinProductPriceByCatgId(int catgId);
        decimal GetMaxProductPriceByCatgId(int catgId);
        FilteredItems FilterItems(ProductCategory productCategory, int pageNo, string sortBy, string priceRange);
        Task<IEnumerable<int>> GetAllProductGroupIdsByCategoryId(int categoryId);
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesIdName();

    }
}
