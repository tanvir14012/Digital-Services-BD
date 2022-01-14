using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Mvc;
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
            cartItemIdNquantity = new List<CartItemIdQty>();
            cartItemBundleIdNquantity = new List<CartItemBundleIdQty>();
        }
        public long CartId { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<CartItemBundleViewModel> CartItemBundlesViewModel { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Subtotal { get; set; }
        public string PromoCode { get; set; }
        public decimal PromoCodeDiscount { get; set; }
        public decimal TaxesAndFees { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountTotal { get; set; }
        public bool IsCreatedNow { get; set; } = false;
        //Ui, (productItemId, quantity) pair
        [BindProperty]
        public ICollection<CartItemIdQty> cartItemIdNquantity { get; set; }
        [BindProperty]
        public ICollection<CartItemBundleIdQty> cartItemBundleIdNquantity { get; set; }
        public string Message { get; set; }
    }
}
