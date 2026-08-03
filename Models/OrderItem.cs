using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProductItem ProductItem { get; set; }
        public virtual ProductStock ProductStock { get; set; }
        public virtual DeliverableItem DeliverableItem { get; set; }
    }
}
