using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductSectionJoinProductItem
    {
        public int ProductSectionId { get; set; }
        public int ProductItemId { get; set; }
        //Navigation property
        public virtual ProductSection ProductSection { get; set; }
        public virtual ProductItem ProductItem { get; set; }
    }
}
