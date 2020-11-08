using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class CartItemBundleViewModel
    {
        public CartItemBundleViewModel()
        {
            IndividualItemsView = new List<ProductItemBundleIndividualItemView>();
            BundlePrice = 0;
        }
        public int ProductItemBundleId { get; set; }
        public bool IsCartCreatedWhenAdded { get; set; }
        public int CreatedCartId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string PriceCurrency { get; set; }
        public decimal BundlePrice { get; set; }
        public decimal BundleDiscount { get; set; }
        public ICollection<ProductItemBundleIndividualItemView> IndividualItemsView { get; set; }
    }
}
