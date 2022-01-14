using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItemPrice
    {
        public int Id { get; set; }
        //Foreign key
        public int ProductItemId { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        //Navigation property
        public virtual ProductItem ProductItem { get; set; }

    }
}
