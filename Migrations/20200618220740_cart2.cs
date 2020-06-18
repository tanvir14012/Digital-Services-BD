using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class cart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "StoreDb",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "StoreDb",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "PriceCurrency",
                schema: "StoreDb",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Vat",
                schema: "StoreDb",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "StoreDb",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ProductItemBundles",
                schema: "StoreDb",
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
                name: "CartJoinProductItemBundles",
                schema: "StoreDb",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductItemBundleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartJoinProductItemBundles", x => new { x.CartId, x.ProductItemBundleId });
                    table.ForeignKey(
                        name: "FK_CartJoinProductItemBundle_CartId",
                        column: x => x.CartId,
                        principalSchema: "StoreDb",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartJoinProductItemBundle_ProductItemBundleId",
                        column: x => x.ProductItemBundleId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductItemBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productItemBundleJoinProductItems",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "ProductItemBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemBundleJoinProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartJoinProductItemBundles_ProductItemBundleId",
                schema: "StoreDb",
                table: "CartJoinProductItemBundles",
                column: "ProductItemBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_productItemBundleJoinProductItems_ProductItemId",
                schema: "StoreDb",
                table: "productItemBundleJoinProductItems",
                column: "ProductItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartJoinProductItemBundles",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "productItemBundleJoinProductItems",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductItemBundles",
                schema: "StoreDb");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "StoreDb",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                schema: "StoreDb",
                table: "CartItems",
                type: "decimal(19, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "StoreDb",
                table: "CartItems",
                type: "decimal(19, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PriceCurrency",
                schema: "StoreDb",
                table: "CartItems",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Vat",
                schema: "StoreDb",
                table: "CartItems",
                type: "decimal(19, 4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
