using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// Join table for tables ProductItem, PromoOffer
    /// </summary>
    public class ProductItemJoinPromoOffer
    {
        //Foreign keys
        public int ProductItemId { get; set; }
        public int PromoOfferId { get; set; }
        //Navigation properties
        public ProductItem ProductItem { get; set; }
        public PromoOffer PromoOffer { get; set; }
    }
}
