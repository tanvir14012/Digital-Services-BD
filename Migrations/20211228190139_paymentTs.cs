using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class paymentTs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurjoPayOrderId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "qzDcV5AEPB0zwjy/G6baqaf4ckW22gJmComg8/XFjCFgQI81NaXXeBUP+Kx/uQMm", new DateTime(2021, 12, 28, 19, 1, 39, 158, DateTimeKind.Utc).AddTicks(3885) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurjoPayOrderId",
                table: "PaymentTransactions");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "2vNcPqicuINJhwG7T7/i0ZfG2X8UJUpqaizMiwC+RKhEaQKTw2LxXkf7tUXVdcDk", new DateTime(2021, 12, 28, 7, 30, 53, 583, DateTimeKind.Utc).AddTicks(3486) });
        }
    }
}
