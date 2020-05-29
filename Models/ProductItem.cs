using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItem
    {
        public ProductItem()
        {
            ProductItemPrice = new HashSet<ProductItemPrice>();
            ProductItemJoinProductCategory = new HashSet<ProductItemJoinProductCategory>();
            ProductItemJoinSearchTagProductItem = new HashSet<ProductItemJoinSearchTagProductItem>();
            ProductItemJoinPromoOffer = new HashSet<ProductItemJoinPromoOffer>();
        }
        public int Id { get; set; }
        //Foreign key
        public int ProductCategoryId { get; set; }
        //Product group id, similar products are grouped together
        public int ProductGroupId { get; set; }
        //Foreign key
        public int ProductFeatureId { get; set; }
        //Foreign key
        public int ProductItemPriceId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ImageUrl { get; set; }
        public string Overview { get; set; }
        public string WhatCanBeDone { get; set; }
        public string HowToConsume { get; set; }
        public string Limitations { get; set; }
        public string IsActive { get; set; }
        public string IsShippable { get; set; }
        public int StockCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        //Navigation property
        public ICollection<ProductItemPrice> ProductItemPrice { get; set; }
        public ICollection<ProductItemJoinProductCategory> ProductItemJoinProductCategory { get; set; }
        public ICollection<ProductItemJoinSearchTagProductItem> ProductItemJoinSearchTagProductItem { get; set; }
        public ICollection<ProductItemJoinPromoOffer> ProductItemJoinPromoOffer { get; set; }
    }
}
