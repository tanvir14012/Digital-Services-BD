using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Digital_Services_BD.Models
{
    public class ProductSection
    {
        public ProductSection()
        {
            ProductSectionJoinProductItem = new HashSet<ProductSectionJoinProductItem>();
            ProductItemIds = new HashSet<int>();
            ProductItems = new HashSet<ProductItem>();
        }
        public int Id { get; set; }
        [StringLength(128, ErrorMessage = "Product section title field should not take more than 128 characters")]
        public string Title { get; set; }
        [StringLength(512, ErrorMessage = "Product section overview field should not take more than 512 characters")]
        public string Overview { get; set; }
        public int Rank { get; set; }
        //Not mapped to database
        [BindProperty]
        public ICollection<int> ProductItemIds { get; set; }
        public virtual ICollection<ProductItem> ProductItems { get; set; }
        //Navigation property
        public virtual ICollection<ProductSectionJoinProductItem> ProductSectionJoinProductItem { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
