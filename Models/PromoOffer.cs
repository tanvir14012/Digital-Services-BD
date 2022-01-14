using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    /// <summary>
    /// An offer can not have more than one currency, offer on same product
    /// with different currency will be treated as different
    /// </summary>
    public class PromoOffer
    {
        public PromoOffer()
        {
            ProductItemJoinPromoOffer = new HashSet<ProductItemJoinPromoOffer>();
        }
        public int Id { get; set; }
        public string PromoCode { get; set; }
        public string OfferCurrency  { get; set; }
        public string CurrencyCountry { get; set; }
        public decimal Discount { get; set; }
        //Foreign key
        public int ProductItemId { get; set; }
        public DateTime OfferBeginsAt { get; set; }
        public DateTime OfferEndsAt { get; set; }
        public DateTime CreatedOn { get; set; }
        //Ef core navigation property
        public virtual ICollection<ProductItemJoinPromoOffer> ProductItemJoinPromoOffer { get; set; }
    }
}
