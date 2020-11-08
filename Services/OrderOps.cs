using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class OrderOps : IOrderOps
    {
        private readonly AppDbContext context;

        public OrderOps(AppDbContext context)
        {
            this.context = context;
        }

        public Order AddOrder(Order order)
        {
            order.CreatedOn = DateTime.UtcNow;
            order.LastModifiedOn = DateTime.UtcNow;
            context.Orders.Add(order);
            try
            {
                context.SaveChanges();
                return order;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Order DeleteOrder(int orderId)
        {
            var order = context.Orders.Find(orderId);
            if (order != null)
            {
                context.Orders.Remove(order);

                try
                {
                    context.SaveChanges();
                    return order;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return context.Orders.AsNoTracking().ToList();
        }

        public Order GetOrder(int orderId)
        {
            var order = context.Orders.Find(orderId);
            if(order != null)
            {
                if(order.TransactionId != null)
                {
                    order.Transaction = context.PaymentTransactions.Find(order.TransactionId);
                }
                if(order.BillingAddressId != null)
                {
                    order.BillingAddress = context.Addresses.Find(order.BillingAddressId);
                }
                if(order.CustomerId != null)
                {
                    order.Customer = context.Customers.Find(order.CustomerId);
                }
            }
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            order.LastModifiedOn = DateTime.UtcNow;
            context.Orders.Update(order);
            try
            {
                context.SaveChanges();
                return order;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool VerifyOrder(string orderId, string trnxId, decimal amountSent, string priceCurrencySent)
        {
            try
            {
                var orderID = Int32.Parse(orderId);
                var trnxID = Int64.Parse(trnxId);

                var verifyOrder = context.Orders.Where(o => o.Id == orderID && o.TransactionId == trnxID
                        && o.TotalPrice == amountSent && o.PriceCurrency == priceCurrencySent).Count() > 0;
                return verifyOrder;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }
    }
}
