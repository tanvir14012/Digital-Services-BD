using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class UserPmverif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserVerificationToken",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "d+QJ2eerbZmLOD1YZPRNi6cOC3oaidxsFjap2SKFfcUNyTSl1oKYB+aBY9OeuqXa", new DateTime(2022, 1, 9, 10, 23, 49, 331, DateTimeKind.Utc).AddTicks(3293) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserVerificationToken",
                table: "PaymentTransactions");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "Cv5iF+V3OZvK/v3wUcvcw2F3IVsevpd2sFTWNpfunAlbg/459L1af8zPyhnk/BvT", new DateTime(2021, 12, 29, 19, 42, 59, 548, DateTimeKind.Utc).AddTicks(1733) });
        }
    }
}
