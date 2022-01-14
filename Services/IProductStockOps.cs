using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IProductStockOps
    {
        Task<ProductStock> AddProductStock(ProductStock ProductStock);
        Task<IEnumerable<ProductStock>> GetAllProductStocks(int pageNo = 1, int itemPerPage = 10);
        Task<ProductStock> GetProductStock(int ProductStockId);
        public Task<int> GetProductStockCount();
        public Task<FilteredProductStocks> FilterProductStocks(int groupId = -1, int categoryId = -1,
            int productId = -1, int pageNo = 1, int ProductStockPerPage = 5, string sortBy = "date_desc");

        Task<ProductStock> DeleteProductStock(int productStockId);
        Task<string> GetProductHierarchy();
        Task<ProductStock> UpdateProductStock(ProductStock productStock);
    }
}
