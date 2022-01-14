using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IOrderOps
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrder(string userId, int pageNo = 1, int itemPerPage = 10);
        Task<Order> GetOrder(int orderId);
        Task<Order> GetOrderItems(int orderId);
        Task<Order> AddBillingInfoToOrder(int orderId, Address billingAddress);
        Task<Order> DeleteOrder(int orderId);
        Task<bool> VerifyOrder(string orderId, string trnxId, decimal amountSent, string priceCurrencySent);
        Task DeleteOrphanCartOrders(int cartId);
        public Task<int> GetOrderCount(string userId);
        public Task<FilteredOrders> FilterOrders(string userId, int total, int pageNo = 1,
            int orderPerPage = 5, string sortBy = "date_desc");
        Task<DeliverablePickResult> PickDeliverables(int orderId);
        Task<DeliverablePickResult> AmendDeliverables(int orderId);
        Task<IList<ProductItemAndQty>> CountMissingDeliverables(int orderId);
    }
}
