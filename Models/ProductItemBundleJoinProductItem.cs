using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItemBundleJoinProductItem
    {
        public int ProductItemBundleId { get; set; }
        public int ProductItemId { get; set; }
        public int ProductItemQuantity { get; set; }

        //Navigation property
        public ProductItemBundle ProductItemBundle { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
