using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

namespace Digital_Services_BD.ViewModels
{
    public class FilteredCategories
    {
        public FilteredCategories()
        {
            CategoriesUnderFilter = new List<ProductCategory>();
        }
        public int TotalCategories { get; set; }
        public IEnumerable<ProductCategory> CategoriesUnderFilter { get; set; }
    }
}
