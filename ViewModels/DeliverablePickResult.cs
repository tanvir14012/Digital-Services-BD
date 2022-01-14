using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class DeliverablePickResult
    {
        public DeliverablePickResult()
        {
            UnpickedProducts = new List<ProductItemAndQty>();
        }
        public IList<ProductItemAndQty> UnpickedProducts { get; set; }
        public Order Order { get; set; }
    }
}
