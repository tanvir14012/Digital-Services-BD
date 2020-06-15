using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class FilteredItems
    {
        public FilteredItems()
        {
            ItemsUnderFilter = new List<ProductItem>();
        }
        public int TotalItems { get; set; }
        public IEnumerable<ProductItem> ItemsUnderFilter { get; set; }
    }
}
