using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CartJoinCartItem
    {
        public int CartId { get; set; }
        public int CartItemId { get; set; }
        //Navigation property
        public Cart Cart { get; set; }
        public CartItem CartItem { get; set; }
    }
}
