using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 16, nullable: true),
                    LastName = table.Column<string>(maxLength: 16, nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    ProfilePicLink = table.Column<string>(maxLength: 64, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    IdCardNo = table.Column<string>(maxLength: 16, nullable: true),
                    IdCardType = table.Column<string>(maxLength: 16, nullable: true),
                    IdCardVerifyPic = table.Column<string>(maxLength: 64, nullable: true),
                    IsVerified = table.Column<bool>(nullable: true, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsCheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FontFamily = table.Column<string>(nullable: true),
                    FawIconClass = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemBundles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    BundleDiscount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    IsActiveNow = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemBundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsShippable = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 128, nullable: true),
                    Overview = table.Column<string>(maxLength: 512, nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoCode = table.Column<string>(maxLength: 16, nullable: false),
                    OfferCurrency = table.Column<string>(maxLength: 16, nullable: false),
                    CurrencyCountry = table.Column<string>(maxLength: 16, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    OfferBeginsAt = table.Column<DateTime>(nullable: false),
                    OfferEndsAt = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchTagProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTagProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 16, nullable: true),
                    LastName = table.Column<string>(maxLength: 16, nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    IsHomeOrBilling = table.Column<bool>(nullable: false),
                    AddressLineOne = table.Column<string>(maxLength: 128, nullable: true),
                    AddressLineTwo = table.Column<string>(maxLength: 128, nullable: true),
                    Mobile = table.Column<string>(maxLength: 16, nullable: true),
                    AltMobile = table.Column<string>(maxLength: 16, nullable: true),
                    Zip = table.Column<string>(maxLength: 16, nullable: true),
                    State = table.Column<string>(maxLength: 16, nullable: true),
                    City = table.Column<string>(maxLength: 16, nullable: true),
                    Country = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carouselJoinCarouselImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false),
                    CarouselId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carouselJoinCarouselImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselJoinCarouselImage_CarouselId",
                        column: x => x.CarouselId,
                        principalTable: "Carousels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartJoinCartItems",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    CartItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartJoinCartItems", x => new { x.CartId, x.CartItemId });
                    table.ForeignKey(
                        name: "FK_CartJoinCartItem_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartJoinCartItem_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productCategoryJoinProductGroup",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategoryJoinProductGroup", x => new { x.ProductCategoryId, x.ProductGroupId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryJoinProductGroup_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryJoinProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartJoinProductItemBundles",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductItemBundleId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartJoinProductItemBundles", x => new { x.CartId, x.ProductItemBundleId });
                    table.ForeignKey(
                        name: "FK_CartJoinProductItemBundle_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartJoinProductItemBundle_ProductItemBundleId",
                        column: x => x.ProductItemBundleId,
                        principalTable: "ProductItemBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productItemBundleJoinProductItems",
                columns: table => new
                {
                    ProductItemBundleId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    ProductItemQuantity = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productItemBundleJoinProductItems", x => new { x.ProductItemBundleId, x.ProductItemId });
                    table.ForeignKey(
                        name: "FK_ProductItemBundleJoinProductItem_ProductItemBundleId",
                        column: x => x.ProductItemBundleId,
                        principalTable: "ProductItemBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemBundleJoinProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(nullable: false),
                    Company = table.Column<string>(maxLength: 64, nullable: true),
                    Developer = table.Column<string>(maxLength: 64, nullable: true),
                    Publisher = table.Column<string>(maxLength: 64, nullable: true),
                    Description = table.Column<string>(maxLength: 2048, nullable: true),
                    RegionCodes = table.Column<string>(maxLength: 1024, nullable: true),
                    RegionCountries = table.Column<string>(maxLength: 1024, nullable: true),
                    DeliveryInfo = table.Column<string>(maxLength: 64, nullable: true),
                    ValidityPeriod = table.Column<string>(maxLength: 64, nullable: true),
                    Genre = table.Column<string>(maxLength: 512, nullable: true),
                    Os = table.Column<string>(maxLength: 512, nullable: true),
                    Platform = table.Column<string>(maxLength: 512, nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    RequirementCpu = table.Column<string>(maxLength: 256, nullable: true),
                    RequirementRam = table.Column<string>(maxLength: 128, nullable: true),
                    RequirementGpu = table.Column<string>(maxLength: 128, nullable: true),
                    RequirementDisk = table.Column<string>(maxLength: 128, nullable: true),
                    DownloadSize = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItemFeatures_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinProductCategory",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemJoinProductCategory", x => new { x.ProductItemId, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductItemJoinProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinProductCategory_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(nullable: false),
                    PriceCurrency = table.Column<string>(maxLength: 16, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItemPrices_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSectionJoinProductItem",
                columns: table => new
                {
                    ProductSectionId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSectionJoinProductItem", x => new { x.ProductSectionId, x.ProductItemId });
                    table.ForeignKey(
                        name: "FK_ProductSectionJoinProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSectionJoinProductItem_ProductSectionId",
                        column: x => x.ProductSectionId,
                        principalTable: "ProductSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinPromoOffer",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(nullable: false),
                    PromoOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemJoinPromoOffer", x => new { x.ProductItemId, x.PromoOfferId });
                    table.ForeignKey(
                        name: "FK_ProductItemJoinPromoOffer_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinPromoOffer_PromoOfferId",
                        column: x => x.PromoOfferId,
                        principalTable: "PromoOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinSearchTagProductItem",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(nullable: false),
                    SearchTagProductItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemJoinSearchTagProductItem", x => new { x.ProductItemId, x.SearchTagProductItemId });
                    table.ForeignKey(
                        name: "FK_ProductItemJoinSearchTagProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId",
                        column: x => x.SearchTagProductItemId,
                        principalTable: "SearchTagProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(nullable: false),
                    ConfirmEmail = table.Column<string>(maxLength: 64, nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    BillingAddressId = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    PriceCurrency = table.Column<string>(maxLength: 8, nullable: false),
                    SendOfferInMail = table.Column<bool>(nullable: false, defaultValue: false),
                    TransactionId = table.Column<long>(nullable: true),
                    IsAnonymousOrder = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(maxLength: 64, nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    TrnxType = table.Column<string>(maxLength: 64, nullable: false),
                    CardType = table.Column<string>(maxLength: 32, nullable: true),
                    CardNo = table.Column<string>(maxLength: 32, nullable: true),
                    BankTrnxId = table.Column<string>(maxLength: 128, nullable: true),
                    CardIssuerBank = table.Column<string>(maxLength: 64, nullable: true),
                    CardIssuerCountry = table.Column<string>(maxLength: 32, nullable: true),
                    CardBrand = table.Column<string>(maxLength: 32, nullable: true),
                    IPAddr = table.Column<string>(maxLength: 64, nullable: true),
                    StatementShow = table.Column<string>(nullable: true),
                    GatewayCurrency = table.Column<string>(maxLength: 8, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    RiskLevel = table.Column<string>(maxLength: 32, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_carouselJoinCarouselImages_CarouselId",
                table: "carouselJoinCarouselImages",
                column: "CarouselId");

            migrationBuilder.CreateIndex(
                name: "IX_CartJoinCartItems_CartItemId",
                table: "CartJoinCartItems",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartJoinProductItemBundles_ProductItemBundleId",
                table: "CartJoinProductItemBundles",
                column: "ProductItemBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_OrderId",
                table: "PaymentTransactions",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productCategoryJoinProductGroup_ProductGroupId",
                table: "productCategoryJoinProductGroup",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_productItemBundleJoinProductItems_ProductItemId",
                table: "productItemBundleJoinProductItems",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemFeatures_ProductItemId",
                table: "ProductItemFeatures",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinProductCategory_ProductCategoryId",
                table: "ProductItemJoinProductCategory",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinPromoOffer_PromoOfferId",
                table: "ProductItemJoinPromoOffer",
                column: "PromoOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinSearchTagProductItem_SearchTagProductItemId",
                table: "ProductItemJoinSearchTagProductItem",
                column: "SearchTagProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemPrices_ProductItemId",
                table: "ProductItemPrices",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionJoinProductItem_ProductItemId",
                table: "ProductSectionJoinProductItem",
                column: "ProductItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "carouselJoinCarouselImages");

            migrationBuilder.DropTable(
                name: "CartJoinCartItems");

            migrationBuilder.DropTable(
                name: "CartJoinProductItemBundles");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "productCategoryJoinProductGroup");

            migrationBuilder.DropTable(
                name: "productItemBundleJoinProductItems");

            migrationBuilder.DropTable(
                name: "ProductItemFeatures");

            migrationBuilder.DropTable(
                name: "ProductItemJoinProductCategory");

            migrationBuilder.DropTable(
                name: "ProductItemJoinPromoOffer");

            migrationBuilder.DropTable(
                name: "ProductItemJoinSearchTagProductItem");

            migrationBuilder.DropTable(
                name: "ProductItemPrices");

            migrationBuilder.DropTable(
                name: "ProductSectionJoinProductItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductItemBundles");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "PromoOffers");

            migrationBuilder.DropTable(
                name: "SearchTagProductItems");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "ProductSections");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
