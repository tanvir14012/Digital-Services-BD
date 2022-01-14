using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public partial class SearchView
    {
        [Required]
        [MinLength(2)]
        public string Term { get; set; }
        public int PageNo { get; set; } = 1;
        public string SortBy { get; set; } = "name";
        public string PriceRange { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<ProductItem> Products { get; set; }
    }
}
