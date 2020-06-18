using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CartItem
    {
        public CartItem()
        {
            CartJoinCartItem = new List<CartJoinCartItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CartId { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }

        //Navigation Property
        public ICollection<CartJoinCartItem> CartJoinCartItem { get; set; }

    }
}
