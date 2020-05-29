using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// Join table that joins tables productCategory, productGroup
    /// </summary>
    public class ProductCategoryJoinProductGroup
    {
        //Foreign keys
        public int ProductCategoryId { get; set; }
        public int ProductGroupId { get; set; }
        //Ef core navigation properties
        public ProductCategory ProductCategory { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
