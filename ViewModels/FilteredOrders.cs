using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class FilteredOrders
    {
        public FilteredOrders()
        {
            OrdersUnderFilter = new List<Order>();
        }

        public int PageNo { get; set; } = 1;
        public int OrderPerPage { get; set; } = 5;
        public string SortBy { get; set; } = "date_desc";
        public int TotalOrders { get; set; } = 0;
        public IEnumerable<Order> OrdersUnderFilter { get; set; }
    }
}
