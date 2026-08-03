using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductStockCount
    {
        public int ProductItemId { get; set; }
        public int Count { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual ProductItem ProductItem { get; set; }
    }
}
