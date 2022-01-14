using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
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

        public async Task<Order> AddOrder(Order order)
        {
            order.CreatedOn = DateTime.UtcNow;
            order.LastModifiedOn = DateTime.UtcNow;
            await context.Orders.AddAsync(order);
            try
            {
                await context.SaveChangesAsync();
                return order;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId);
            if (order != null)
            {
                context.Orders.Remove(order);

                try
                {
                    await context.SaveChangesAsync();
                    return order;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public async Task DeleteOrphanCartOrders(int cartId)
        {
            var orders = await context.Orders
                .Include(order => order.OrderItems)
                .Include(order => order.OrderProductItemBundles)
                .Where(order => order.CartId == cartId && order.Status == OrderStatus.AWAITING).ToListAsync();

            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    order.OrderItems.Clear();
                    order.OrderProductItemBundles.Clear();
                    context.Orders.Remove(order);
                }

                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Order>> GetAllOrder(string userId, int pageNo = 1, int itemPerPage = 10)
        {
            var orders = await context.Orders.AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.BillingAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(item => item.ProductItem)
                .Include(o => o.OrderProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                .Include(o => o.Transaction)
                .Where(o => o.CustomerId == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Skip((pageNo - 1) * itemPerPage)
                .Take(itemPerPage)
                .ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(int orderId)
        {
            var order = await context.Orders.AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.BillingAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(item => item.ProductItem)
                .Include(o => o.OrderProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                .Include(o => o.Transaction)
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<Order> GetOrderItems(int orderId)
        {
            var order = await context.Orders.AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(item => item.ProductItem)
                        .ThenInclude(pi => pi.ProductItemPrice)
                .Include(o => o.OrderProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                        .ThenInclude(pib => pib.ProductItemBundleJoinProductItem)
                            .ThenInclude(join => join.ProductItem)
                                .ThenInclude(pi => pi.ProductItemPrice)
                .Include(o => o.Transaction)
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<Order> AddBillingInfoToOrder(int orderId, Address billingAddress)
        {
            var order = await context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.LastModifiedOn = DateTime.UtcNow;
                order.BillingAddress = billingAddress;
                context.Orders.Update(order);
                try
                {
                    await context.SaveChangesAsync();
                    return order;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return null;
        }
        public async Task<bool> VerifyOrder(string orderId, string trnxId, decimal amountSent, string priceCurrencySent)
        {
            try
            {
                var orderID = Int64.Parse(orderId);
                var trnxID = Int64.Parse(trnxId);

                var verifyOrder = await context.Orders.Where(o => o.Id == orderID && o.TransactionId == trnxID
                        && o.GrandTotal == amountSent && o.PriceCurrency == priceCurrencySent).AnyAsync();
                return verifyOrder;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<FilteredOrders> FilterOrders(string userId, int total, int pageNo = 1,
            int orderPerPage = 5, string sortBy = "date_desc")
        {
            var orders = context.Orders.AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.BillingAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(item => item.ProductItem)
                .Include(o => o.OrderProductItemBundles)
                    .ThenInclude(bundle => bundle.ProductItemBundle)
                .Include(o => o.Transaction)
                .Where(o => o.CustomerId == userId);

            switch (sortBy)
            {
                case "date_desc":
                    orders = orders.OrderByDescending(o => o.CreatedOn);
                    break;
                case "date_asc":
                    orders = orders.OrderBy(o => o.CreatedOn);
                    break;
                case "price_desc":
                    orders = orders.OrderByDescending(o => o.GrandTotal);
                    break;
                case "price_asc":
                    orders = orders.OrderBy(o => o.GrandTotal);
                    break;
            }

            return new FilteredOrders
            {
                TotalOrders = total,
                OrdersUnderFilter = await orders.Skip((pageNo - 1) * orderPerPage)
                .Take(orderPerPage)
                .ToListAsync(),
                PageNo = pageNo,
                OrderPerPage = orderPerPage,
                SortBy = sortBy
            };
        }

        public async Task<int> GetOrderCount(string userId)
        {
            var count = await context.Orders.AsNoTracking().CountAsync(o => o.CustomerId == userId);
            return count;
        }

        public async Task<DeliverablePickResult> PickDeliverables(int orderId)
        {
            var pickResult = new DeliverablePickResult();
            var unpickedDeliverables = new Dictionary<int, ProductItemAndQty>();
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var order = await context.Orders
                   .Include(o => o.OrderItems)
                       .ThenInclude(item => item.ProductItem)
                            .ThenInclude(pi => pi.ProductItemPrice)
                   .Include(o => o.OrderProductItemBundles)
                       .ThenInclude(bundle => bundle.ProductItemBundle)
                            .ThenInclude(pib => pib.ProductItemBundleJoinProductItem)
                                .ThenInclude(join => join.ProductItem)
                                    .ThenInclude(pi => pi.ProductItemPrice)
                   .Include(o => o.Transaction)
                   .Include(o => o.Deliverable)
                        .ThenInclude(d => d.DeliverableItems)
                            .ThenInclude(di => di.ProductStock)
                    .Include(o => o.Deliverable)
                        .ThenInclude(d => d.DeliverableBundles)
                            .ThenInclude(db => db.DeliverableBundleItems)
                                .ThenInclude(dbi => dbi.ProductStock)
                   .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order != null && order.Transaction.SurjoPayCode == 1000)
                {
                    //If not tried yet to deliver
                    if (order.Deliverable == null)
                    {
                        order.Deliverable = new Deliverable
                        {
                            DeliverableItems = new List<DeliverableItem>(),
                            DeliverableBundles = new List<DeliverableBundle>()
                        };
                        foreach (var orderItem in order.OrderItems)
                        {
                            //Pick N(=quantity) items from the stock
                            var stocks = await context.ProductStocks.AsNoTracking()
                                .Where(ps => ps.ProductItemId == orderItem.ProductItemId && ps.Status == ProductStockStatus.ACTIVE)
                                .Take(orderItem.Quantity).ToListAsync();

                            if (stocks.Count < orderItem.Quantity)
                            {
                                var itemQty = new ProductItemAndQty
                                {
                                    ProductItem = orderItem.ProductItem,
                                    Quantity = orderItem.Quantity - stocks.Count
                                };
                                unpickedDeliverables.Add(orderItem.ProductItem.Id, itemQty);
                            }

                            foreach (var stock in stocks)
                            {
                                order.Deliverable.DeliverableItems.Add(new DeliverableItem
                                {
                                    OrderItemId = orderItem.Id,
                                    ProductStockId = stock.Id

                                });
                            }
                        }

                        foreach (var bundle in order.OrderProductItemBundles)
                        {
                            var deliverableBundle = new DeliverableBundle
                            {
                                ProductItemBundleId = bundle.ProductItemBundleId,
                                DeliverableBundleItems = new List<DeliverableBundleItem>()
                            };

                            foreach (var bundleItem in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                            {
                                //Pick N(=quantity) items from the stock
                                var stocks = await context.ProductStocks.AsNoTracking()
                                    .Where(ps => ps.ProductItemId == bundleItem.ProductItemId && ps.Status == ProductStockStatus.ACTIVE)
                                    .Take(bundle.Quantity * bundleItem.ProductItemQuantity).ToListAsync();

                                if (stocks.Count < bundle.Quantity * bundleItem.ProductItemQuantity)
                                {
                                    int count = bundle.Quantity * bundleItem.ProductItemQuantity - stocks.Count;
                                    if (unpickedDeliverables.ContainsKey(bundleItem.ProductItem.Id))
                                    {
                                        var itemQty = unpickedDeliverables[bundleItem.ProductItem.Id];
                                        itemQty.Quantity += count;
                                    }
                                    else
                                    {
                                        unpickedDeliverables[bundleItem.ProductItem.Id] = new ProductItemAndQty
                                        {
                                            ProductItem = bundleItem.ProductItem,
                                            Quantity = count
                                        };
                                    }
                                }

                                foreach (var stock in stocks)
                                {
                                    deliverableBundle.DeliverableBundleItems.Add(new DeliverableBundleItem
                                    {
                                        ProductStockId = stock.Id
                                    });
                                }
                            }
                            order.Deliverable.DeliverableBundles.Add(deliverableBundle);
                        }

                        await context.SaveChangesAsync();

                        //Now have the Id fields, update stocks
                        foreach (var deliverableItem in order.Deliverable.DeliverableItems)
                        {
                            deliverableItem.ProductStock = await context.ProductStocks.Include(ps => ps.ProductItem)
                                .FirstOrDefaultAsync(ps => ps.Id == deliverableItem.ProductStockId);

                            if (deliverableItem.ProductStock != null)
                            {
                                deliverableItem.ProductStock.Status = ProductStockStatus.DELIVERED;
                                deliverableItem.ProductStock.DeliverableItemId = deliverableItem.Id;
                            }
                        }

                        order.Deliverable.DeliverableBundles = await context.DeliverableBundles
                            .Include(db => db.DeliverableBundleItems)
                                .ThenInclude(dbi => dbi.ProductStock)
                                    .ThenInclude(ps => ps.ProductItem)
                            .Where(db => db.DeliverableId == order.Deliverable.Id).ToListAsync();

                        foreach (var deliverableBundle in order.Deliverable.DeliverableBundles)
                        {

                            foreach (var bundleItem in deliverableBundle.DeliverableBundleItems)
                            {
                                if (bundleItem.ProductStock != null)
                                {
                                    bundleItem.ProductStock.Status = ProductStockStatus.DELIVERED;
                                    bundleItem.ProductStock.DeliverableBundleItemId = bundleItem.Id;
                                }
                            }
                        }

                        if (!unpickedDeliverables.Any())
                        {
                            order.Deliverable.Completed = true;
                            order.Status = OrderStatus.COMPLETED;
                        }
                        else if (unpickedDeliverables.Any())
                        {
                            order.Status = OrderStatus.PARTIAL_COMPLETED;
                        }

                        await context.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();

                pickResult.UnpickedProducts = unpickedDeliverables.Values.ToList();
                pickResult.Order = order;
                return pickResult;
            }
            catch
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        public async Task<DeliverablePickResult> AmendDeliverables(int orderId)
        {
            var pickResult = new DeliverablePickResult();
            var unpickedDeliverables = new Dictionary<int, ProductItemAndQty>();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var order = await context.Orders
                  .Include(o => o.OrderItems)
                      .ThenInclude(item => item.ProductItem)
                             .ThenInclude(pi => pi.ProductItemPrice)
                  .Include(o => o.OrderProductItemBundles)
                      .ThenInclude(bundle => bundle.ProductItemBundle)
                           .ThenInclude(pib => pib.ProductItemBundleJoinProductItem)
                               .ThenInclude(join => join.ProductItem)
                                     .ThenInclude(pi => pi.ProductItemPrice)
                  .Include(o => o.Transaction)
                  .Include(o => o.Deliverable)
                       .ThenInclude(d => d.DeliverableItems)
                           .ThenInclude(di => di.ProductStock)
                   .Include(o => o.Deliverable)
                       .ThenInclude(d => d.DeliverableBundles)
                           .ThenInclude(db => db.DeliverableBundleItems)
                               .ThenInclude(dbi => dbi.ProductStock)
                  .FirstOrDefaultAsync(o => o.Id == orderId);

                
                if (order != null && order.Transaction.SurjoPayCode == 1000 && order.Deliverable != null && !order.Deliverable.Completed)
                {
                    //Order items
                    foreach (var orderItem in order.OrderItems)
                    {
                        int required = orderItem.Quantity -
                            order.Deliverable.DeliverableItems.Count(di => di.OrderItemId == orderItem.Id);
                        if (required > 0)
                        {
                            var stocks = await context.ProductStocks.AsNoTracking()
                            .Where(ps => ps.ProductItemId == orderItem.ProductItemId && ps.Status == ProductStockStatus.ACTIVE)
                            .Take(required).ToListAsync();

                            if (stocks.Count < required)
                            {
                                var itemQty = new ProductItemAndQty
                                {
                                    ProductItem = orderItem.ProductItem,
                                    Quantity = required - stocks.Count
                                };
                                unpickedDeliverables.Add(orderItem.ProductItem.Id, itemQty);
                            }

                            foreach (var stock in stocks)
                            {
                                order.Deliverable.DeliverableItems.Add(new DeliverableItem
                                {
                                    OrderItemId = orderItem.Id,
                                    ProductStockId = stock.Id
                                });
                            }
                        }
                    }

                    //Bundle items
                    foreach (var bundle in order.OrderProductItemBundles)
                    {
                        //Deliverable bundle created before, check & add
                        if (order.Deliverable.DeliverableBundles.Any(db => db.ProductItemBundleId == bundle.ProductItemBundleId))
                        {
                            var deliverableBundle = order.Deliverable.DeliverableBundles
                                .First(db => db.ProductItemBundleId == bundle.ProductItemBundleId);

                            foreach (var join in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                            {
                                var required = bundle.Quantity * join.ProductItemQuantity - deliverableBundle.DeliverableBundleItems
                                    .Count(dbi => dbi.ProductStock.ProductItemId == join.ProductItemId);

                                if (required > 0)
                                {
                                    var stocks = await context.ProductStocks.AsNoTracking()
                                    .Where(ps => ps.ProductItemId == join.ProductItemId && ps.Status == ProductStockStatus.ACTIVE)
                                    .Take(required).ToListAsync();

                                    if (stocks.Count < required)
                                    {
                                        int count = required - stocks.Count;
                                        if (unpickedDeliverables.ContainsKey(join.ProductItem.Id))
                                        {
                                            var itemQty = unpickedDeliverables[join.ProductItem.Id];
                                            itemQty.Quantity += count;
                                        }
                                        else
                                        {
                                            unpickedDeliverables[join.ProductItem.Id] = new ProductItemAndQty 
                                            { 
                                                ProductItem = join.ProductItem,
                                                Quantity = count
                                            };
                                        }
                                    }

                                    foreach (var stock in stocks)
                                    {
                                        deliverableBundle.DeliverableBundleItems.Add(new DeliverableBundleItem
                                        {
                                            ProductStockId = stock.Id
                                        });
                                    }
                                }
                            }
                        }
                    }

                    await context.SaveChangesAsync();

                    //Now have the Id fields, update stocks
                    foreach (var deliverableItem in order.Deliverable.DeliverableItems)
                    {
                        deliverableItem.ProductStock = await context.ProductStocks.Include(ps => ps.ProductItem)
                            .FirstOrDefaultAsync(ps => ps.Id == deliverableItem.ProductStockId);

                        if (deliverableItem.ProductStock != null)
                        {
                            deliverableItem.ProductStock.Status = ProductStockStatus.DELIVERED;
                            deliverableItem.ProductStock.DeliverableItemId = deliverableItem.Id;
                        }
                    }

                    order.Deliverable.DeliverableBundles = await context.DeliverableBundles
                        .Include(db => db.DeliverableBundleItems)
                            .ThenInclude(dbi => dbi.ProductStock)
                                .ThenInclude(ps => ps.ProductItem)
                        .Where(db => db.DeliverableId == order.Deliverable.Id).ToListAsync();

                    foreach (var deliverableBundle in order.Deliverable.DeliverableBundles)
                    {

                        foreach (var bundleItem in deliverableBundle.DeliverableBundleItems)
                        {
                            if (bundleItem.ProductStock != null)
                            {
                                bundleItem.ProductStock.Status = ProductStockStatus.DELIVERED;
                                bundleItem.ProductStock.DeliverableBundleItemId = bundleItem.Id;
                            }
                        }
                    }

                    if (!unpickedDeliverables.Any())
                    {
                        order.Deliverable.Completed = true;
                        order.Status = OrderStatus.COMPLETED;
                    }
                    else if(unpickedDeliverables.Any())
                    {
                        order.Status = OrderStatus.PARTIAL_COMPLETED;
                    }
                    await context.SaveChangesAsync();
                    
                }

                await transaction.CommitAsync();
                pickResult.UnpickedProducts = unpickedDeliverables.Values.ToList();
                pickResult.Order = order;
                return pickResult;
            }
            catch
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        public async Task<IList<ProductItemAndQty>> CountMissingDeliverables(int orderId)
        {
            var unpickedDeliverables = new Dictionary<int, ProductItemAndQty>();

            try
            {
                var order = await context.Orders
                  .Include(o => o.OrderItems)
                      .ThenInclude(item => item.ProductItem)
                  .Include(o => o.OrderProductItemBundles)
                      .ThenInclude(bundle => bundle.ProductItemBundle)
                           .ThenInclude(pib => pib.ProductItemBundleJoinProductItem)
                               .ThenInclude(join => join.ProductItem)
                  .Include(o => o.Deliverable)
                       .ThenInclude(d => d.DeliverableItems)
                           .ThenInclude(di => di.ProductStock)
                   .Include(o => o.Deliverable)
                       .ThenInclude(d => d.DeliverableBundles)
                           .ThenInclude(db => db.DeliverableBundleItems)
                               .ThenInclude(dbi => dbi.ProductStock)
                  .FirstOrDefaultAsync(o => o.Id == orderId);


                if (order != null && order.Transaction.SurjoPayCode == 1000 && order.Deliverable != null)
                {
                    //Order items
                    foreach (var orderItem in order.OrderItems)
                    {
                        int required = orderItem.Quantity -
                            order.Deliverable.DeliverableItems.Count(di => di.OrderItemId == orderItem.Id);
                        if (required > 0)
                        {
                            unpickedDeliverables.Add(orderItem.ProductItem.Id, new ProductItemAndQty { 
                                ProductItem = orderItem.ProductItem,
                                Quantity = required
                            });
                        }
                    }

                    //Bundle items
                    foreach (var bundle in order.OrderProductItemBundles)
                    {
                        //Deliverable bundle created before, check & add
                        if (order.Deliverable.DeliverableBundles.Any(db => db.ProductItemBundleId == bundle.ProductItemBundleId))
                        {
                            var deliverableBundle = order.Deliverable.DeliverableBundles
                                .First(db => db.ProductItemBundleId == bundle.ProductItemBundleId);

                            foreach (var join in bundle.ProductItemBundle.ProductItemBundleJoinProductItem)
                            {
                                var required = bundle.Quantity * join.ProductItemQuantity - deliverableBundle.DeliverableBundleItems
                                    .Count(dbi => dbi.ProductStock.ProductItemId == join.ProductItemId);

                                if (required > 0)
                                {
                                    if (unpickedDeliverables.ContainsKey(join.ProductItem.Id))
                                    {
                                        var itemQty = unpickedDeliverables[join.ProductItem.Id];
                                        itemQty.Quantity += required;
                                    }
                                    else
                                    {
                                        unpickedDeliverables.Add(join.ProductItem.Id, new ProductItemAndQty
                                        {
                                            ProductItem = join.ProductItem,
                                            Quantity = required
                                        });
                                    }
                                }
                            }
                        }
                    }

                    return unpickedDeliverables.Values.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
