using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class deliverable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_OrderItemId",
                table: "ProductStocks");

            migrationBuilder.DropIndex(
                name: "IX_ProductStocks_OrderItemId",
                table: "ProductStocks");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "ProductStocks",
                newName: "DeliverableItemId");

            migrationBuilder.AddColumn<int>(
                name: "DeliverableBundleItemId",
                table: "ProductStocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliverableId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductStockId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliverables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverable_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliverableBundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliverableId = table.Column<int>(type: "int", nullable: false),
                    ProductItemBundleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverableBundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverableBundle_DeliverableId",
                        column: x => x.DeliverableId,
                        principalTable: "Deliverables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliverableBundles_ProductItemBundles_ProductItemBundleId",
                        column: x => x.ProductItemBundleId,
                        principalTable: "ProductItemBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliverableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliverableId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: true),
                    ProductStockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverableItem_DeliverableId",
                        column: x => x.DeliverableId,
                        principalTable: "Deliverables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliverableItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliverableItem_ProductStockId",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliverableBundleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliverableBundleId = table.Column<int>(type: "int", nullable: false),
                    ProductStockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverableBundleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverableBundleItem_DeliverableBundleId",
                        column: x => x.DeliverableBundleId,
                        principalTable: "DeliverableBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliverableBundleItem_ProductStockId",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "Cv5iF+V3OZvK/v3wUcvcw2F3IVsevpd2sFTWNpfunAlbg/459L1af8zPyhnk/BvT", new DateTime(2021, 12, 29, 19, 42, 59, 548, DateTimeKind.Utc).AddTicks(1733) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductStockId",
                table: "OrderItem",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableBundleItems_DeliverableBundleId",
                table: "DeliverableBundleItems",
                column: "DeliverableBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableBundleItems_ProductStockId",
                table: "DeliverableBundleItems",
                column: "ProductStockId",
                unique: true,
                filter: "[ProductStockId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableBundles_DeliverableId",
                table: "DeliverableBundles",
                column: "DeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableBundles_ProductItemBundleId",
                table: "DeliverableBundles",
                column: "ProductItemBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableItems_DeliverableId",
                table: "DeliverableItems",
                column: "DeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableItems_OrderItemId",
                table: "DeliverableItems",
                column: "OrderItemId",
                unique: true,
                filter: "[OrderItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableItems_ProductStockId",
                table: "DeliverableItems",
                column: "ProductStockId",
                unique: true,
                filter: "[ProductStockId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_OrderId",
                table: "Deliverables",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_ProductStocks_ProductStockId",
                table: "OrderItem",
                column: "ProductStockId",
                principalTable: "ProductStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_ProductStocks_ProductStockId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "DeliverableBundleItems");

            migrationBuilder.DropTable(
                name: "DeliverableItems");

            migrationBuilder.DropTable(
                name: "DeliverableBundles");

            migrationBuilder.DropTable(
                name: "Deliverables");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ProductStockId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DeliverableBundleItemId",
                table: "ProductStocks");

            migrationBuilder.DropColumn(
                name: "DeliverableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductStockId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "DeliverableItemId",
                table: "ProductStocks",
                newName: "OrderItemId");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "Byu6TcLDWT3ays+YJ7iL3126gHkK4KHon5f7x6bK22x+S3gD5uAIq+UKfSb0/bP4", new DateTime(2021, 12, 29, 8, 36, 14, 126, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_OrderItemId",
                table: "ProductStocks",
                column: "OrderItemId",
                unique: true,
                filter: "[OrderItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_OrderItemId",
                table: "ProductStocks",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
