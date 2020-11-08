using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface IOrderOps
    {
        Order AddOrder(Order order);
        IEnumerable<Order> GetAllOrder();
        Order GetOrder(int orderId);
        Order UpdateOrder(Order order);
        Order DeleteOrder(int orderId);
        bool VerifyOrder(string orderId, string trnxId, decimal amountSent, string priceCurrencySent);
    }
}
