using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CartProductItemBundle
    {
        public int CartId { get; set; }
        public int ProductItemBundleId { get; set; }
        public int Quantity { get; set; }
        //Navigation property
        public virtual Cart Cart { get; set; }
        public virtual ProductItemBundle ProductItemBundle { get; set; }
    }
}
