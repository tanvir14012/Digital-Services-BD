using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

namespace Digital_Services_BD.ViewModels
{
    public class OrderEmailTemplate
    {
        public OrderEmailTemplate()
        {
            MissingItems = new List<ProductItemAndQty>();
            EmailLinkedResources = new List<EmailLinkedResource>();
        }
        public Order Order { get; set; }
        public IList<ProductItemAndQty> MissingItems { get; set; }
        public string ShopName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ShopEmail { get; set; }
        public string ShopPhone { get; set; }
        public string ShopEmail2 { get; set; }
        public string ShopPhone2 { get; set; }
        public string Website { get; set; }
        public string RecipeintName { get; set; }
        public IList<EmailLinkedResource> EmailLinkedResources { get; set; }
    }
}
