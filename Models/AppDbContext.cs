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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
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
        public DbSet<ProductSection> ProductSections { get; set; }
        public DbSet<ProductSectionJoinProductItem> ProductSectionJoinProductItem { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<CarouselJoinCarouselImage> carouselJoinCarouselImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CartJoinCartItem> CartJoinCartItems { get; set; }
        public DbSet<ProductItemBundle> ProductItemBundles { get; set; }
        public DbSet<ProductItemBundleJoinProductItem> productItemBundleJoinProductItems { get; set; }
        public DbSet<CartJoinProductItemBundle> CartJoinProductItemBundles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Address table property design
            builder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.FirstName).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.LastName).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.AddressType).IsRequired();
                entity.Property(e => e.AddressLineOne).IsUnicode().HasMaxLength(128);
                entity.Property(e => e.AddressLineTwo).IsUnicode().HasMaxLength(128);
                entity.Property(e => e.Mobile).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.AltMobile).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.Zip).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.City).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.State).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.Country).IsUnicode().HasMaxLength(16);

                entity.HasOne(e => e.Customer)
                      .WithMany(e => e.Addresses)
                      .HasForeignKey(e => e.CustomerId)
                      .HasConstraintName("FK_Address_CustomerId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
            //Customer table property design
            builder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode().IsRequired().HasMaxLength(16);
                entity.Property(e => e.LastName).IsUnicode().IsRequired().HasMaxLength(16);
                entity.Property(e => e.ProfilePicLink).HasMaxLength(64);
                entity.Property(e => e.BirthDate).IsUnicode();
                entity.Property(e => e.IdCardNo).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.IdCardVerifyPic).HasMaxLength(64);
                entity.Property(e => e.IsVerified).HasDefaultValue<bool>(false);
                entity.Ignore(e => e.AddressIds);

            });
            //ProductItem table property design
            builder.Entity<ProductItem>(entity =>
            {
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
            builder.Entity<ProductItemPrice>(entity =>
            {
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
            builder.Entity<ProductCategory>(entity =>
            {
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
            builder.Entity<ProductItemJoinProductCategory>(entity =>
            {
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
            builder.Entity<ProductGroup>(entity =>
            {
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
            builder.Entity<ProductCategoryJoinProductGroup>(entity =>
            {
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
            builder.Entity<SearchTagProductItem>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.TagName).IsRequired().HasMaxLength(128);
            });

            //ProductItemJoinSearchTagProductItem table key, foreign key design
            builder.Entity<ProductItemJoinSearchTagProductItem>(entity =>
            {
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
            builder.Entity<PromoOffer>(entity =>
            {
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

            builder.Entity<ProductItemJoinPromoOffer>(entity =>
            {
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

            builder.Entity<ProductItemFeature>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.Company).HasMaxLength(64);
                entity.Property(e => e.Developer).HasMaxLength(64);
                entity.Property(e => e.Publisher).HasMaxLength(64);
                entity.Property(e => e.Description).HasMaxLength(2048);
                entity.Property(e => e.RegionCodes).HasMaxLength(1024);
                entity.Property(e => e.RegionCountries).HasMaxLength(1024);
                entity.Property(e => e.DeliveryInfo).HasMaxLength(64);
                entity.Property(e => e.ValidityPeriod).HasMaxLength(64);
                entity.Property(e => e.Genre).HasMaxLength(512);
                entity.Property(e => e.Os).HasMaxLength(512);
                entity.Property(e => e.Platform).HasMaxLength(512);
                entity.Property(e => e.RequirementCpu).HasMaxLength(256);
                entity.Property(e => e.RequirementRam).HasMaxLength(128);
                entity.Property(e => e.RequirementGpu).HasMaxLength(128);
                entity.Property(e => e.RequirementDisk).HasMaxLength(128);
                entity.Property(e => e.DownloadSize).HasMaxLength(64);
            });

            //Product section for landing page like featured, you may like, hot deals etc.
            builder.Entity<ProductSection>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Title).HasMaxLength(128);
                entity.Property(e => e.Overview).HasMaxLength(512);
                entity.Ignore(e => e.ProductItemIds);
                entity.Ignore(e => e.ProductItems);
            });
            //Foreign key design
            builder.Entity<ProductSectionJoinProductItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductSectionId, e.ProductItemId });
                entity.HasOne(e => e.ProductSection)
                      .WithMany(e => e.ProductSectionJoinProductItem)
                      .HasForeignKey(e => e.ProductSectionId)
                      .HasConstraintName("FK_ProductSectionJoinProductItem_ProductSectionId")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.ProductItem)
                     .WithMany(e => e.ProductSectionJoinProductItem)
                     .HasForeignKey(e => e.ProductItemId)
                     .HasConstraintName("FK_ProductSectionJoinProductItem_ProductItemId")
                     .OnDelete(DeleteBehavior.Cascade);
            });
            //Carousel
            builder.Entity<Carousel>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Name).HasMaxLength(128);
            });
            builder.Entity<CarouselJoinCarouselImage>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.ImageUrl).HasMaxLength(256);
                entity.Ignore(e => e.Image);
                entity.HasOne(e => e.Carousel)
                      .WithMany(e => e.CarouselJoinCarouselImage)
                      .HasForeignKey(e => e.CarouselId)
                      .HasConstraintName("FK_CarouselJoinCarouselImage_CarouselId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
            //Cart
            builder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.IsCheckedOut).IsRequired();
                entity.Property(e => e.UserId).HasDefaultValue(null);
            });

            builder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.CartId).IsRequired();
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Ignore(e => e.Name);
                entity.Ignore(e => e.PriceCurrency);
                entity.Ignore(e => e.Price);
                entity.Ignore(e => e.Discount);
                entity.Ignore(e => e.Vat);
            });

            builder.Entity<CartJoinCartItem>(entity => {
                entity.HasKey(e => new { e.CartId, e.CartItemId });
                entity.HasOne(e => e.Cart)
                      .WithMany(e => e.CartJoinCartItem)
                      .HasForeignKey(e => e.CartId)
                      .HasConstraintName("FK_CartJoinCartItem_CartId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.CartItem)
                      .WithMany(e => e.CartJoinCartItem)
                      .HasForeignKey(e => e.CartItemId)
                      .HasConstraintName("FK_CartJoinCartItem_CartItemId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //Product Bundle
            builder.Entity<ProductItemBundle>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.BundleDiscount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.IsActiveNow).IsRequired();
            });

            builder.Entity<ProductItemBundleJoinProductItem>(entity => {
                entity.HasKey(e => new { e.ProductItemBundleId, e.ProductItemId });
                entity.Property(e => e.ProductItemQuantity).IsRequired().HasDefaultValue(1);
                entity.HasOne(e => e.ProductItemBundle)
                      .WithMany(e => e.ProductItemBundleJoinProductItem)
                      .HasForeignKey(e => e.ProductItemBundleId)
                      .HasConstraintName("FK_ProductItemBundleJoinProductItem_ProductItemBundleId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductItemBundleJoinProductItem)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductItemBundleJoinProductItem_ProductItemId")
                      .OnDelete(DeleteBehavior.Restrict); // Do not let product item deleted 

            });
            //CartJoinProductItemBundle
            builder.Entity<CartJoinProductItemBundle>(entity => {
                entity.HasKey(e => new { e.CartId, e.ProductItemBundleId });
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(1);
                entity.HasOne(e => e.Cart)
                      .WithMany(e => e.CartJoinProductItemBundle)
                      .HasForeignKey(e => e.CartId)
                      .HasConstraintName("FK_CartJoinProductItemBundle_CartId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ProductItemBundle)
                      .WithMany(e => e.CartJoinProductItemBundle)
                      .HasForeignKey(e => e.ProductItemBundleId)
                      .HasConstraintName("FK_CartJoinProductItemBundle_ProductItemBundleId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
            //Order
            builder.Entity<Order>(entity => {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.CartId).IsRequired();
                entity.Property(e => e.ConfirmEmail).IsRequired().HasMaxLength(64);
                entity.Property(e => e.SendOfferInMail).HasDefaultValue(false);
                entity.Property(e => e.TotalPrice).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.PriceCurrency).IsRequired().HasMaxLength(8);
                entity.Ignore(e => e.Cart);
                entity.Ignore(e => e.Customer);
            });
            //Transaction
            builder.Entity<PaymentTransaction>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().UseIdentityColumn();
                entity.Property(e => e.OrderId).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(64);
                entity.Property(e => e.TrnxType).IsRequired().HasMaxLength(64);
                entity.Property(e => e.Amount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.GatewayCurrency).IsRequired().HasMaxLength(8);
                entity.Property(e => e.IPAddr).HasMaxLength(64);
                entity.Property(e => e.RiskLevel).HasMaxLength(32);
                entity.Property(e => e.CardType).HasMaxLength(32);
                entity.Property(e => e.CardNo).HasMaxLength(32);
                entity.Property(e => e.CardIssuerCountry).HasMaxLength(32);
                entity.Property(e => e.CardIssuerBank).HasMaxLength(64);
                entity.Property(e => e.CardBrand).HasMaxLength(32);
                entity.Property(e => e.BankTrnxId).HasMaxLength(128);

                entity.HasOne(e => e.Order)
                      .WithOne(e => e.Transaction)
                      .HasForeignKey<PaymentTransaction>(e => e.OrderId)
                      .HasConstraintName("FK_PaymentTransaction_OrderId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
