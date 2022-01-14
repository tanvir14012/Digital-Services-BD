using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public partial class CartConfirm
    {
        public int CartId { get; set; }
        public string Email { get; set; }
        public bool SendOffers { get; set; }
    }
}
