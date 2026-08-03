using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountTotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "2vNcPqicuINJhwG7T7/i0ZfG2X8UJUpqaizMiwC+RKhEaQKTw2LxXkf7tUXVdcDk", new DateTime(2021, 12, 28, 7, 30, 53, 583, DateTimeKind.Utc).AddTicks(3486) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountTotal",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "A7DbL0PCHB9vKEWsGgh77w8jglqvtEN0fnM5Jdy3wZSyBq2xyVTj6mBSZVgDRBnE", new DateTime(2021, 12, 27, 14, 57, 48, 903, DateTimeKind.Utc).AddTicks(5708) });
        }
    }
}
