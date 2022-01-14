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
            CartItems = new HashSet<CartItem>();
            CartProductItemBundles = new HashSet<CartProductItemBundle>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        //Navigation Property
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<CartProductItemBundle> CartProductItemBundles { get; set; }
    }
}
