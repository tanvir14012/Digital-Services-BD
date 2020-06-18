using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CartJoinProductItemBundle
    {
        public int CartId { get; set; }
        public int ProductItemBundleId { get; set; }
        //Navigation property
        public Cart Cart { get; set; }
        public ProductItemBundle ProductItemBundle { get; set; }
    }
}
