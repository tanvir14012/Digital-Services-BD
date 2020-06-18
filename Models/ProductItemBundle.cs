using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItemBundle
    {
        public ProductItemBundle()
        {
            ProductItemBundleJoinProductItem = new List<ProductItemBundleJoinProductItem>();
            CartJoinProductItemBundle = new List<CartJoinProductItemBundle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BundleDiscount { get; set; }
        public bool IsActiveNow { get; set; } = true;
        public DateTime CreatedOn { get; set; }

        //Navigation property
        public ICollection<ProductItemBundleJoinProductItem> ProductItemBundleJoinProductItem { get; set; }
        public ICollection<CartJoinProductItemBundle> CartJoinProductItemBundle { get; set; }
    }
}
