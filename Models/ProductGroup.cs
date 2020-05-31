using Digital_Services_BD.Utilities;
using Microsoft.AspNetCore.Http;
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
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Name should contain no more than 128 characters")]
        [Display(Name = "Product Group Name")]
        public string Name { get; set; }

        [Display(Name = "Image Upload")]
        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { "jpg", "png", "gif", "tiff" })]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Product Group Overview")]
        [MaxLength(256,ErrorMessage = "This field contain no more than 256 characters")]
        public string Overview { get; set; }
        [StringLength(256, ErrorMessage = "This field should contain no more than 256 characters")]
        [Display(Name = "What Can Be Done")]
        public string WhatCanBeDone { get; set; }
        [StringLength(256, ErrorMessage = "This field should contain no more than 256 characters")]
        [Display(Name = "How To Consume")]
        public string HowToConsume { get; set; }

        [StringLength(256, ErrorMessage = "This field should contain no more than 256 characters")]
        public string Limitations { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        //Navigation property
        public ICollection<ProductCategoryJoinProductGroup> ProductCategoryJoinProductGroup { get; set; }
    }
}
