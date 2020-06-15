using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
