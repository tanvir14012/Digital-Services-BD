using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// Join table that joins tables productItem, productCategory.
    /// </summary>
    public class ProductItemJoinProductCategory
    {
        //Foreign keys
        public int ProductItemId { get; set; }
        public int ProductCategoryId { get; set; }
        //Ef core navigation properties
        public virtual ProductItem ProductItem { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
