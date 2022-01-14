using Digital_Services_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class OrderDispatchTemplate
    {
        public OrderDispatchTemplate()
        {
            MissingItems = new Dictionary<string, int>();
        }
        public Deliverable Deliverable { get; set; }
        public Dictionary<string, int> MissingItems { get; set; }
        public string LogoPath { get; set; }
        public string ShopName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ShopEmail { get; set; }
        public string ShopPhone { get; set; }
        public string Website { get; set; }
        public string RecipeintName { get; set; }
    }
}
