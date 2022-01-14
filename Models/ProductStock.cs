using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductStock
    {
        public int Id { get; set; }

        [Required]
        public int ProductItemId { get; set; }

        [Required]
        [Encrypted]
        public string MainCode { get; set; }
        [Encrypted]
        public string AuxiliaryCode { get; set; }
        [Encrypted]
        public string OptionA { get; set; }
        [Encrypted]
        public string OptionB { get; set; }
        [Encrypted]
        public string OptionC { get; set; }
        public int? DeliverableItemId { get; set; }
        public int? DeliverableBundleItemId { get; set; }
        public string VendorInfo { get; set; }

        [MaxLength(500)]
        public string Remark { get; set; }
        public ProductStockStatus Status { get; set; } = ProductStockStatus.ACTIVE;
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public virtual ProductItem ProductItem { get; set; }
        public virtual DeliverableItem DeliverableItem { get; set; }
        public virtual DeliverableBundleItem DeliverableBundleItem { get; set; }
    }

    public enum ProductStockStatus
    {
        ACTIVE = 1,
        DELIVERED = 2,
        HALTED = 3,
        INVALID = 4
    }
}
