using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
            CartItemBundlesViewModel = new List<CartItemBundleViewModel>();
        }
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<CartItemBundleViewModel> CartItemBundlesViewModel { get; set; }
        public decimal Subtotal { get; set; }
        public string PromoCode { get; set; }
        public decimal PromoCodeDiscount { get; set; }
        public decimal TaxesAndFees { get; set; }
        public decimal Total { get; set; }
    }
}
