using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public class ProductItemCustomFieldViewModel
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
