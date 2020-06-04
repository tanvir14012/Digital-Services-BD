using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class product2 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "StoreDb",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "StoreDb",
                newName: "Addresses",
                newSchema: "StoreDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                schema: "StoreDb",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "StoreDb",
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
                schema: "StoreDb",
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
                schema: "StoreDb",
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
                name: "ProductItems",
                schema: "StoreDb",
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
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoOffers",
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
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchTagProductItems",
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
                    table.PrimaryKey("PK_SearchTagProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productCategoryJoinProductGroup",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryJoinProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductGroups",
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
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinProductCategory_ProductItemId",
                        column: x => x.ProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemPrices",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductItems",
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
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinPromoOffer_PromoOfferId",
                        column: x => x.PromoOfferId,
                        principalSchema: "StoreDb",
                        principalTable: "PromoOffers",
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
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId",
                        column: x => x.SearchTagProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "SearchTagProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productCategoryJoinProductGroup_ProductGroupId",
                schema: "StoreDb",
                table: "productCategoryJoinProductGroup",
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
                name: "IX_ProductItemPrices_ProductItemId",
                schema: "StoreDb",
                table: "ProductItemPrices",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_BillingAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "BillingAddrId",
                principalSchema: "StoreDb",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_HomeAddrId",
                schema: "StoreDb",
                table: "AspNetUsers",
                column: "HomeAddrId",
                principalSchema: "StoreDb",
                principalTable: "Addresses",
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
                name: "Languages",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "productCategoryJoinProductGroup",
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
                name: "ProductItemPrices",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductGroups",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "PromoOffers",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "SearchTagProductItems",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItems",
                schema: "StoreDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                schema: "StoreDb",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "StoreDb",
                newName: "Address",
                newSchema: "StoreDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "StoreDb",
                table: "Address",
                column: "Id");

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
