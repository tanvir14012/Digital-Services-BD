using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductItemPrice> ProductItemPrices { get; set; }
        public DbSet<PromoOffer> PromoOffers { get; set; }
        public DbSet<SearchTagProductItem> SearchTagProductItems { get; set; }
        public DbSet<ProductCategoryJoinProductGroup> productCategoryJoinProductGroup { get; set; }
        public DbSet<ProductItemJoinProductCategory> ProductItemJoinProductCategory { get; set; }
        public DbSet<ProductItemJoinPromoOffer> ProductItemJoinPromoOffer { get; set; }
        public DbSet<ProductItemJoinSearchTagProductItem> ProductItemJoinSearchTagProductItem { get; set; }
        public DbSet<ProductItemFeature> ProductItemFeatures { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("StoreDb");
            //Address table property design
            builder.Entity<Address>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.AddressLineOne).IsUnicode().HasMaxLength(128);
                entity.Property(e => e.AddressLineTwo).IsUnicode().HasMaxLength(128);
                entity.Property(e => e.Mobile).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.AltMobile).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.Zip).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.City).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.State).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.Country).IsUnicode().HasMaxLength(16);
            });
            //Customer table property design
            builder.Entity<Customer>(entity => {
                entity.Property(e => e.FirstName).IsUnicode().IsRequired().HasMaxLength(16);
                entity.Property(e => e.LastName).IsUnicode().IsRequired().HasMaxLength(16);
                entity.Property(e => e.Gender).IsUnicode().HasMaxLength(8);
                entity.Property(e => e.ProfilePicLink).HasMaxLength(64);
                entity.Property(e => e.BirthDate).IsUnicode();
                entity.Property(e => e.IdCardNo).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.IdCardVerifyPic).HasMaxLength(64);
                entity.Property(e => e.IdCardType).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.IsVerified).HasDefaultValue<bool>(false);

                entity.HasOne(c => c.HomeAddress)
                      .WithOne(a => a.HomeCustomer)
                      .HasForeignKey<Customer>(c => c.HomeAddrId)
                      .HasConstraintName("FK_Customer_HomeAddrId")
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.BillingAddress)
                      .WithOne(a => a.BillingCustomer)
                      .HasForeignKey<Customer>(c => c.BillingAddrId)
                      .HasConstraintName("FK_Customer_BillingAddrId")
                      .OnDelete(DeleteBehavior.NoAction);
            });
            //ProductItem table property design
            builder.Entity<ProductItem>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Overview).IsRequired().HasMaxLength(256);
                entity.Property(e => e.HowToConsume).HasMaxLength(256);
                entity.Property(e => e.WhatCanBeDone).HasMaxLength(256);
                entity.Property(e => e.Limitations).HasMaxLength(256);
                entity.Property(e => e.ImageUrl).HasMaxLength(256);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.IsShippable).IsRequired();
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.LastModifiedOn).HasDefaultValueSql("getutcdate()");
                entity.Ignore(e => e.Image);
                entity.Ignore(e => e.CategoryIds);
                entity.Ignore(e => e.Categories);
            });

            //ProductItemPrice table property design
            builder.Entity<ProductItemPrice>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.PriceCurrency).IsRequired().HasMaxLength(16);
                entity.Property(e => e.Discount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Vat).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.LastModifiedOn).HasDefaultValueSql("getutcdate()");
            });
            //ProductCategory table property design
            builder.Entity<ProductCategory>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Overview).IsRequired().HasMaxLength(256);
                entity.Property(e => e.HowToConsume).HasMaxLength(256);
                entity.Property(e => e.WhatCanBeDone).HasMaxLength(256);
                entity.Property(e => e.Limitations).HasMaxLength(256);
                entity.Property(e => e.ImageUrl).HasMaxLength(256);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.LastModifiedOn).HasDefaultValueSql("getutcdate()");
                entity.Ignore(e => e.Image);
                entity.Ignore(e => e.AllItemIds);
                entity.Ignore(e => e.AllItems);
            });

            //ProductItemJoinProductCategory table key, foreign key design
            builder.Entity<ProductItemJoinProductCategory>(entity => {
                entity.HasKey(e => new { e.ProductItemId, e.ProductCategoryId });
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductItemJoinProductCategory)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductItemJoinProductCategory_ProductItemId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ProductCategory)
                      .WithMany(e => e.ProductItemJoinProductCategory)
                      .HasForeignKey(e => e.ProductCategoryId)
                      .HasConstraintName("FK_ProductItemJoinProductCategory_ProductCategoryId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //ProductGroup table property design
            builder.Entity<ProductGroup>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.ImageUrl).HasMaxLength(256);
                entity.Property(e => e.Overview).IsRequired().HasMaxLength(256);
                entity.Property(e => e.HowToConsume).HasMaxLength(256);
                entity.Property(e => e.WhatCanBeDone).HasMaxLength(256);
                entity.Property(e => e.Limitations).HasMaxLength(256);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.LastModifiedOn).HasDefaultValueSql("getutcdate()");
                entity.Ignore(e => e.Image);
                entity.Ignore(e => e.AllCategories);
                entity.Ignore(e => e.AllCategoryIds);
            });

            //ProductCategoryJoinProductGroup table key, foreign key design
            builder.Entity<ProductCategoryJoinProductGroup>(entity => {
                entity.HasKey(e => new { e.ProductCategoryId, e.ProductGroupId });
                entity.HasOne(e => e.ProductGroup)
                      .WithMany(e => e.ProductCategoryJoinProductGroup)
                      .HasForeignKey(e => e.ProductGroupId)
                      .HasConstraintName("FK_ProductCategoryJoinProductGroup_ProductGroupId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ProductCategory)
                      .WithMany(e => e.ProductCategoryJoinProductGroup)
                      .HasForeignKey(e => e.ProductCategoryId)
                      .HasConstraintName("FK_ProductCategoryJoinProductGroup_ProductCategoryId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //SearchTagProductItem table property design
            builder.Entity<SearchTagProductItem>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.TagName).IsRequired().HasMaxLength(128);
            });

            //ProductItemJoinSearchTagProductItem table key, foreign key design
            builder.Entity<ProductItemJoinSearchTagProductItem>(entity => {
                entity.HasKey(e => new { e.ProductItemId, e.SearchTagProductItemId });
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductItemJoinSearchTagProductItem)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductItemJoinSearchTagProductItem_ProductItemId");
                entity.HasOne(e => e.SearchTagProductItem)
                      .WithMany(e => e.ProductItemJoinSearchTagProductItem)
                      .HasForeignKey(e => e.SearchTagProductItemId)
                      .HasConstraintName("FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId");
            });
            //PromoOffer table property design
            builder.Entity<PromoOffer>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.PromoCode).IsRequired().HasMaxLength(16);
                entity.Property(e => e.OfferCurrency).IsRequired().HasMaxLength(16);
                entity.Property(e => e.CurrencyCountry).IsRequired().HasMaxLength(16);
                entity.Property(e => e.OfferBeginsAt).IsRequired();
                entity.Property(e => e.OfferEndsAt).IsRequired();
                entity.Property(e => e.Discount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            });

            builder.Entity<ProductItemJoinPromoOffer>(entity => {
                entity.HasKey(e => new { e.ProductItemId, e.PromoOfferId });
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductItemJoinPromoOffer)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductItemJoinPromoOffer_ProductItemId");
                entity.HasOne(e => e.PromoOffer)
                      .WithMany(e => e.ProductItemJoinPromoOffer)
                      .HasForeignKey(e => e.PromoOfferId)
                      .HasConstraintName("FK_ProductItemJoinPromoOffer_PromoOfferId");
            });

            builder.Entity<ProductItemFeature>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Company).HasMaxLength(64);
                entity.Property(e => e.Developer).HasMaxLength(64);
                entity.Property(e => e.Publisher).HasMaxLength(64);
                entity.Property(e => e.Description).HasMaxLength(2048);
                entity.Property(e => e.RegionCodes).HasMaxLength(1024);
                entity.Property(e => e.RegionCountries).HasMaxLength(1024);
                entity.Property(e => e.DeliveryInfo).HasMaxLength(64);
                entity.Property(e => e.ValidityPeriod).HasMaxLength(64);
                entity.Property(e => e.Genre).HasMaxLength(128);
                entity.Property(e => e.Os).HasMaxLength(256);
                entity.Property(e => e.Platform).HasMaxLength(256);
                entity.Property(e => e.RequirementCpu).HasMaxLength(256);
                entity.Property(e => e.RequirementRam).HasMaxLength(128);
                entity.Property(e => e.RequirementGpu).HasMaxLength(128);
                entity.Property(e => e.RequirementDisk).HasMaxLength(128);
                entity.Property(e => e.DownloadSize).HasMaxLength(64);
            });
        }
    }
}
