using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddrId",
                schema: "StoreDb",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeAddrId",
                schema: "StoreDb",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 64, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 64, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false),
                    ProductFeatureId = table.Column<int>(nullable: false),
                    ProductItemPriceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 64, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 64, nullable: true),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    WhatCanBeDone = table.Column<string>(maxLength: 256, nullable: true),
                    HowToConsume = table.Column<string>(maxLength: 256, nullable: true),
                    Limitations = table.Column<string>(maxLength: 256, nullable: true),
                    IsActive = table.Column<string>(nullable: false),
                    IsShippable = table.Column<string>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoOffer",
                schema: "StoreDb",
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
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoOffer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchTagProductItem",
                schema: "StoreDb",
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
                    table.PrimaryKey("PK_SearchTagProductItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryJoinProductGroup",
                schema: "StoreDb",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryJoinProductGroup", x => new { x.ProductCategoryId, x.ProductGroupId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryJoinProductGroup_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryJoinProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinProductCategory",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinProductCategory_ProductItemId",
                        column: x => x.ProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemPrice",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(nullable: false),
                    PriceCurrency = table.Column<string>(maxLength: 16, nullable: false),
                    CurrencyCountry = table.Column<string>(maxLength: 32, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItemPrice_ProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinPromoOffer",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinPromoOffer_PromoOfferId",
                        column: x => x.PromoOfferId,
                        principalSchema: "StoreDb",
                        principalTable: "PromoOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemJoinSearchTagProductItem",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId",
                        column: x => x.SearchTagProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "SearchTagProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryJoinProductGroup_ProductGroupId",
                schema: "StoreDb",
                table: "ProductCategoryJoinProductGroup",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinProductCategory_ProductCategoryId",
                schema: "StoreDb",
                table: "ProductItemJoinProductCategory",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinPromoOffer_PromoOfferId",
                schema: "StoreDb",
                table: "ProductItemJoinPromoOffer",
                column: "PromoOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemJoinSearchTagProductItem_SearchTagProductItemId",
                schema: "StoreDb",
                table: "ProductItemJoinSearchTagProductItem",
                column: "SearchTagProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemPrice_ProductItemId",
                schema: "StoreDb",
                table: "ProductItemPrice",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_BillingAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "BillingAddrId",
                principalSchema: "StoreDb",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_HomeAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "HomeAddrId",
                principalSchema: "StoreDb",
                principalTable: "Address",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_BillingAddrId",
                schema: "StoreDb",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_HomeAddrId",
                schema: "StoreDb",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductCategoryJoinProductGroup",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItemJoinProductCategory",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItemJoinPromoOffer",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItemJoinSearchTagProductItem",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItemPrice",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "PromoOffer",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "SearchTagProductItem",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItem",
                schema: "StoreDb");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "BillingAddrId",
                principalSchema: "StoreDb",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "HomeAddrId",
                principalSchema: "StoreDb",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
