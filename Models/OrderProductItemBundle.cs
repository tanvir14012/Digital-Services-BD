using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class OrderProductItemBundle
    {
        public int OrderId { get; set; }
        public int ProductItemBundleId { get; set; }
        public int Quantity { get; set; }
        public string PriceCurrency { get; set; }
        public decimal BundlePrice { get; set; }
        public decimal BundleDiscount { get; set; }
        //Navigation property
        public virtual Order Order { get; set; }
        public virtual ProductItemBundle ProductItemBundle { get; set; }
    }
}
