using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class CartItemViewModel
    {
        public CartItem CartItem { get; set; }
        public bool IsCartCreatedWhenAdded { get; set; }
        public int CreatedCartId { get; set; }
        public string Message { get; set; }
        public string MessageClass { get; set; }
    }
}
