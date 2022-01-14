using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public partial class HomePageItems
    {
        public Carousel Carousel { get; set; }
        public ICollection<ProductSection> ProductSections { get; set; }
        public IList<ProductItemBundle> Bundles { get; set; }
    }
}
