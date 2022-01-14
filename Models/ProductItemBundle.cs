using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItemBundle
    {
        public ProductItemBundle()
        {
            ProductItemBundleJoinProductItem = new HashSet<ProductItemBundleJoinProductItem>();
            CartProductItemBundle = new HashSet<CartProductItemBundle>();
            OrderProductItemBundle = new HashSet<OrderProductItemBundle>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public decimal BundleDiscount { get; set; }

        [Required]
        public bool IsActiveNow { get; set; } = true;
        public DateTime CreatedOn { get; set; }

        //Navigation property
        public virtual ICollection<ProductItemBundleJoinProductItem> ProductItemBundleJoinProductItem { get; set; }
        public virtual ICollection<CartProductItemBundle> CartProductItemBundle { get; set; }
        public virtual ICollection<OrderProductItemBundle> OrderProductItemBundle { get; set; }
    }
}
