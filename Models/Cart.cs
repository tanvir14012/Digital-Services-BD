using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Cart
    {
        public Cart()
        {
            CartJoinCartItem = new List<CartJoinCartItem>();
            CartJoinProductItemBundle = new List<CartJoinProductItemBundle>();
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        //Navigation Property
        public ICollection<CartJoinCartItem> CartJoinCartItem { get; set; }
        public ICollection<CartJoinProductItemBundle> CartJoinProductItemBundle { get; set; }
    }
}
