using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductGroup
    {
        public ProductGroup()
        {
            ProductCategoryJoinProductGroup = new HashSet<ProductCategoryJoinProductGroup>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [DisplayName("Image")]
        [MaxLength(64)]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(256)]
        public string Overview { get; set; }
        [MaxLength(256)]
        public string WhatCanBeDone { get; set; }
        [MaxLength(256)]
        public string HowToConsume { get; set; }
        [MaxLength(256)]
        public string Limitations { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        //Navigation property
        public ICollection<ProductCategoryJoinProductGroup> ProductCategoryJoinProductGroup { get; set; }
    }
}
