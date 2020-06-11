using Digital_Services_BD.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItem
    {
        public ProductItem()
        {
            ProductItemPrice = new List<ProductItemPrice>();
            ProductItemJoinProductCategory = new List<ProductItemJoinProductCategory>();
            ProductItemJoinSearchTagProductItem = new List<ProductItemJoinSearchTagProductItem>();
            ProductItemJoinPromoOffer = new List<ProductItemJoinPromoOffer>();
            CategoryIds = new HashSet<int>();
            Categories = new List<ProductCategory>();
            ProductItemFeature = new ProductItemFeature();
            ProductSectionJoinProductItem = new List<ProductSectionJoinProductItem>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Product name field should contain no more than 128 characters")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { "jpg", "png", "gif", "tiff" })]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Product Category Overview")]
        [MaxLength(256, ErrorMessage = "Product overview field should contain no more than 256 characters")]
        public string Overview { get; set; }
        [StringLength(256, ErrorMessage = "What can be done field should contain no more than 256 characters")]
        [Display(Name = "What Can Be Done")]
        public string WhatCanBeDone { get; set; }
        [StringLength(256, ErrorMessage = "How to consume field should contain no more than 256 characters")]
        [Display(Name = "How To Consume")]
        public string HowToConsume { get; set; }

        [StringLength(256, ErrorMessage = "Limitations field should contain no more than 256 characters")]
        public string Limitations { get; set; }
        public bool IsActive { get; set; }
        public bool IsShippable { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public ProductItemFeature ProductItemFeature { get; set; }
        //Not mappded to database
        [BindProperty]
        public ICollection<int> CategoryIds { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }
        //Navigation property
        [BindProperty]
        public IList<ProductItemPrice> ProductItemPrice { get; set; }
        public ICollection<ProductItemJoinProductCategory> ProductItemJoinProductCategory { get; set; }
        public ICollection<ProductItemJoinSearchTagProductItem> ProductItemJoinSearchTagProductItem { get; set; }
        public ICollection<ProductItemJoinPromoOffer> ProductItemJoinPromoOffer { get; set; }
        public ICollection<ProductSectionJoinProductItem> ProductSectionJoinProductItem { get; set; }
    }
}
