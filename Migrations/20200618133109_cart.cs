using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PriceCurrency = table.Column<string>(maxLength: 16, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsCheckedOut = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartJoinCartItems",
                schema: "StoreDb",
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
                        principalSchema: "StoreDb",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartJoinCartItem_CartItemId",
                        column: x => x.CartItemId,
                        principalSchema: "StoreDb",
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartJoinCartItems_CartItemId",
                schema: "StoreDb",
                table: "CartJoinCartItems",
                column: "CartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartJoinCartItems",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "CartItems",
                schema: "StoreDb");
        }
    }
}
