using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Utilities;

using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Digital_Services_BD.Models
{
    public class AppDbContext : IdentityDbContext, IDataProtectionKeyContext
    {
        // Get key and IV from a Base64String or any other ways.
        private readonly byte[] _encryptionKey = new byte[] { 175, 53, 213, 191, 20, 245, 21, 171, 206, 43, 210, 121, 128, 212, 139, 192, 165, 20, 236, 255, 183, 68, 175, 169, 96, 20, 151, 219, 116, 45, 62, 235 };
        private readonly byte[] _encryptionIV = new byte[] { 244, 244, 195, 197, 87, 186, 25, 127, 217, 130, 169, 205, 145, 72, 105, 210 };
        private readonly byte[] _salt = new byte[] { 6, 8, 137, 144, 221, 39, 87, 101, 208, 52, 75, 26, 149, 76, 217, 235 };
        private readonly EncryptionHelper _encryptionHelper;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            var key = PasswordUtility.PkbDf2(_salt, Convert.ToBase64String(_encryptionKey));
            var iv = PasswordUtility.PkbDf2(_salt, Convert.ToBase64String(_encryptionIV), 16);
            this._encryptionHelper = new EncryptionHelper(key, iv);
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<ProductItemPrice> ProductItemPrices { get; set; }
        public virtual DbSet<PromoOffer> PromoOffers { get; set; }
        public virtual DbSet<SearchTagProductItem> SearchTagProductItems { get; set; }
        public virtual DbSet<ProductCategoryJoinProductGroup> ProductCategoryJoinProductGroup { get; set; }
        public virtual DbSet<ProductItemJoinProductCategory> ProductItemJoinProductCategory { get; set; }
        public virtual DbSet<ProductItemJoinPromoOffer> ProductItemJoinPromoOffer { get; set; }
        public virtual DbSet<ProductItemJoinSearchTagProductItem> ProductItemJoinSearchTagProductItem { get; set; }
        public virtual DbSet<ProductItemFeature> ProductItemFeatures { get; set; }
        public virtual DbSet<ProductItemCustomField> ProductItemCustomFields { get; set; }
        public virtual DbSet<ProductSection> ProductSections { get; set; }
        public virtual DbSet<ProductSectionJoinProductItem> ProductSectionJoinProductItem { get; set; }
        public virtual DbSet<Carousel> Carousels { get; set; }
        public virtual DbSet<CarouselJoinCarouselImage> CarouselJoinCarouselImages { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ProductItemBundle> ProductItemBundles { get; set; }
        public virtual DbSet<ProductItemBundleJoinProductItem> ProductItemBundleJoinProductItems { get; set; }
        public virtual DbSet<CartProductItemBundle> CartProductItemBundles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual DbSet<PaymentGwConfig> PaymentGwConfigs { get; set; }
        public virtual DbSet<SmtpConfig> SmtpConfigs { get; set; }
        public virtual DbSet<ProductStock> ProductStocks { get; set; }
        public virtual DbSet<ProductStockCount> ProductStockCounts { get; set; }
        public virtual DbSet<EncryptionKey> EncryptionKeys { get; set; }
        public virtual DbSet<Deliverable> Deliverables { get; set; }
        public virtual DbSet<DeliverableItem> DeliverableItems { get; set; }
        public virtual DbSet<DeliverableBundle> DeliverableBundles { get; set; }
        public virtual DbSet<DeliverableBundleItem> DeliverableBundleItems { get; set; }

        public virtual DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Enable encryption for properties marked with [Encrypted] attribute
            builder.ApplyEncryption(this._encryptionHelper);

            //Address table property design
            builder.Entity<Address>(entity =>
            {
                //The property named as 'Id' is primary key and identity by default convention.
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
                entity.Property(e => e.FirstName).IsUnicode().HasMaxLength(16);
                entity.Property(e => e.LastName).IsUnicode().HasMaxLength(16);
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

                entity.HasMany(p => p.ProductItemPrice)
                      .WithOne(pr => pr.ProductItem)
                      .HasForeignKey(pr => pr.ProductItemId)
                      .HasConstraintName("FK_ProductItemPrice_ProductId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //ProductItemPrice table property design
            builder.Entity<ProductItemPrice>(entity =>
            {

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

            //Product item custom fields
            builder.Entity<ProductItemCustomField>(entity =>
            {
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductItemCustomFields)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductItemCustomField_ProductItemId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //Product section for landing page like featured, you may like, hot deals etc.
            builder.Entity<ProductSection>(entity =>
            {

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

                entity.Property(e => e.Name).HasMaxLength(128);
            });
            builder.Entity<CarouselJoinCarouselImage>(entity =>
            {

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

                entity.Property(e => e.IsCheckedOut).IsRequired();
                entity.Property(e => e.UserId).HasDefaultValue(null);

                entity.HasMany(e => e.CartItems)
                      .WithOne(e => e.Cart)
                      .HasForeignKey(e => e.CartId)
                      .HasConstraintName("FK_CartItem_CartId")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.CartProductItemBundles)
                      .WithOne(e => e.Cart)
                      .HasForeignKey(e => e.CartId)
                      .HasConstraintName("FK_CartProductItemBundles_CartId")
                      .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<CartItem>(entity =>
            {

                entity.Property(e => e.CartId).IsRequired();
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Ignore(e => e.Name);
                entity.Ignore(e => e.PriceCurrency);
                entity.Ignore(e => e.Price);
                entity.Ignore(e => e.Discount);
                entity.Ignore(e => e.Vat);
            });


            //Product Bundle
            builder.Entity<ProductItemBundle>(entity =>
            {

                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.BundleDiscount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.IsActiveNow).IsRequired();
            });

            builder.Entity<ProductItemBundleJoinProductItem>(entity =>
            {
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
            //CartProductItemBundle
            builder.Entity<CartProductItemBundle>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductItemBundleId });
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(1);
                entity.HasOne(e => e.Cart)
                      .WithMany(e => e.CartProductItemBundles)
                      .HasForeignKey(e => e.CartId)
                      .HasConstraintName("FK_CartJoinProductItemBundle_CartId")
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ProductItemBundle)
                      .WithMany(e => e.CartProductItemBundle)
                      .HasForeignKey(e => e.ProductItemBundleId)
                      .HasConstraintName("FK_CartJoinProductItemBundle_ProductItemBundleId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
            //Order
            builder.Entity<Order>(entity =>
            {

                entity.Property(e => e.ConfirmEmail).IsRequired().HasMaxLength(64);
                entity.Property(e => e.SendOfferInMail).HasDefaultValue(false);
                entity.Property(e => e.GrandTotal).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.PriceCurrency).IsRequired().HasMaxLength(8);
                entity.HasOne(e => e.Customer)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(e => e.CustomerId)
                      .HasConstraintName("FK_Order_CustomerId")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.OrderItems)
                     .WithOne(e => e.Order)
                     .HasForeignKey(e => e.OrderId)
                     .HasConstraintName("FK_OrderItem_OrderId")
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.OrderProductItemBundles)
                      .WithOne(e => e.Order)
                      .HasForeignKey(e => e.OrderId)
                      .HasConstraintName("FK_OrderProductItemBundles_OrderId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<OrderItem>(entity =>
            {

                entity.Property(e => e.OrderId).IsRequired();
                entity.Property(e => e.ProductItemId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });

            //OrderProductItemBundle
            builder.Entity<OrderProductItemBundle>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductItemBundleId });
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(1);
                entity.HasOne(e => e.Order)
                      .WithMany(e => e.OrderProductItemBundles)
                      .HasForeignKey(e => e.OrderId)
                      .HasConstraintName("FK_OrderJoinProductItemBundle_OrderId")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ProductItemBundle)
                      .WithMany(e => e.OrderProductItemBundle)
                      .HasForeignKey(e => e.ProductItemBundleId)
                      .HasConstraintName("FK_OrderJoinProductItemBundle_ProductItemBundleId")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //Transaction
            builder.Entity<PaymentTransaction>(entity =>
            {
                entity.Property(e => e.OrderId).IsRequired();
                entity.HasIndex(e => e.SurjoPayOrderId);
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Amount).IsRequired().HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Currency).HasMaxLength(8);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.City).HasMaxLength(32);
                entity.Property(e => e.Phone).HasMaxLength(32);
                entity.Property(e => e.RiskLevel).HasMaxLength(32);
                entity.Property(e => e.SurjoPayMsg).HasMaxLength(32);

                entity.HasOne(e => e.Order)
                      .WithOne(e => e.Transaction)
                      .HasForeignKey<PaymentTransaction>(e => e.OrderId)
                      .HasConstraintName("FK_PaymentTransaction_OrderId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PaymentGwConfig>(entity =>
            {

                entity.Property(e => e.GwName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.SuccessCallbackUrl).HasMaxLength(150);
                entity.Property(e => e.CancelCallbackUrl).HasMaxLength(150);
                entity.Property(e => e.FailCallbackUrl).HasMaxLength(150);
                entity.Property(e => e.ApiRoot).HasMaxLength(150);
                entity.Property(e => e.RedirectUrl).IsRequired().HasMaxLength(250);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("getutcdate()");
            });

            builder.Entity<SmtpConfig>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired()
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedDateTime)
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.CreatedUserId).HasMaxLength(50);

                entity.Property(e => e.FromAddress)
                    .IsRequired()
                    .HasMaxLength(320);

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(200);

                entity.Property(e => e.Server)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedDateTime)
                      .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.UpdatedUserId).HasMaxLength(50);

                entity.Property(e => e.UseAuthentication).HasDefaultValue(true);

                entity.Property(e => e.UseSecureConnection).HasDefaultValue(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            builder.Entity<ProductStock>(entity =>
            {
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.CreateTime);
                entity.Property(e => e.Remark).HasMaxLength(500);
                entity.HasOne(e => e.ProductItem)
                      .WithMany(e => e.ProductStocks)
                      .HasForeignKey(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductStock_ProductItemId")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProductStockCount>(entity =>
            {
                entity.HasKey(e => e.ProductItemId);
                entity.HasOne(e => e.ProductItem)
                      .WithOne(e => e.ProductStockCount)
                      .HasForeignKey<ProductStockCount>(e => e.ProductItemId)
                      .HasConstraintName("FK_ProductStockCount_ProductItemId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<EncryptionKey>().HasData(new EncryptionKey
            {
                Id = 1,
                Key = PasswordUtility.HashPassword("TaNvIr14012!@#"),
                LastUpdated = DateTime.UtcNow
            });

            builder.Entity<Deliverable>(entity =>
            {
                entity.HasOne(e => e.Order)
                      .WithOne(e => e.Deliverable)
                      .HasForeignKey<Deliverable>(e => e.OrderId)
                      .HasConstraintName("FK_Deliverable_OrderId")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.DeliverableItems)
                      .WithOne(e => e.Deliverable)
                      .HasForeignKey(e => e.DeliverableId)
                      .HasConstraintName("FK_DeliverableItem_DeliverableId")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.DeliverableBundles)
                     .WithOne(e => e.Deliverable)
                     .HasForeignKey(e => e.DeliverableId)
                     .HasConstraintName("FK_DeliverableBundle_DeliverableId")
                     .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<DeliverableItem>(entity =>
            {
                entity.HasOne(e => e.ProductStock)
                      .WithOne(e => e.DeliverableItem)
                      .HasForeignKey<DeliverableItem>(e => e.ProductStockId)
                      .HasConstraintName("FK_DeliverableItem_ProductStockId")
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.OrderItem)
                     .WithOne(e => e.DeliverableItem)
                     .HasForeignKey<DeliverableItem>(e => e.OrderItemId)
                     .HasConstraintName("FK_DeliverableItem_OrderItemId")
                     .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.ProductStock)
                     .WithOne(e => e.DeliverableItem)
                     .HasForeignKey<DeliverableItem>(e => e.ProductStockId)
                     .HasConstraintName("FK_DeliverableItem_ProductStockId")
                     .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<DeliverableBundleItem>(entity =>
            {
                entity.HasOne(e => e.ProductStock)
                      .WithOne(e => e.DeliverableBundleItem)
                      .HasForeignKey<DeliverableBundleItem>(e => e.ProductStockId)
                      .HasConstraintName("FK_DeliverableBundleItem_ProductStockId")
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.DeliverableBundle)
                     .WithMany(e => e.DeliverableBundleItems)
                     .HasForeignKey(e => e.DeliverableBundleId)
                     .HasConstraintName("FK_DeliverableBundleItem_DeliverableBundleId")
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.ProductStock)
                     .WithOne(e => e.DeliverableBundleItem)
                     .HasForeignKey<DeliverableBundleItem>(e => e.ProductStockId)
                     .HasConstraintName("FK_DeliverableBundleItem_ProductStockId")
                     .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
