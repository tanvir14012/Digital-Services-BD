using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ProductItemJoinProductCategory = new HashSet<ProductItemJoinProductCategory>();
            ProductCategoryJoinProductGroup = new HashSet<ProductCategoryJoinProductGroup>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //Product group id, similar products are grouped together
        public int GroupId { get; set; }
        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public string Overview { get; set; }
        public string WhatCanBeDone { get; set; }
        public string HowToConsume { get; set; }
        public string Limitations { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        //Navigation property
        public ICollection<ProductCategoryJoinProductGroup> ProductCategoryJoinProductGroup { get; set; }
        public ICollection<ProductItemJoinProductCategory> ProductItemJoinProductCategory { get; set; }
    }
}
