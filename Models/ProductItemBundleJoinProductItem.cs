using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// Represents an individual product item and it's quantity in the bundle.
    /// </summary>
    public class ProductItemBundleJoinProductItem
    {

        public int ProductItemBundleId { get; set; }

        [Required]
        public int ProductItemId { get; set; }

        [Required]
        public int ProductItemQuantity { get; set; }

        //Navigation property
        public virtual ProductItemBundle ProductItemBundle { get; set; }
        public virtual ProductItem ProductItem { get; set; }
    }
}
