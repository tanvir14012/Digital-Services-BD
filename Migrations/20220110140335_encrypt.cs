using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class encrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "DXDvxHEYGkFHu8o9P18rivDO9Y2/2lmFY3PAT0DRoTiU7SKN1Ej/bGdIt7LTBwMN", new DateTime(2022, 1, 10, 14, 3, 35, 53, DateTimeKind.Utc).AddTicks(1898) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "d+QJ2eerbZmLOD1YZPRNi6cOC3oaidxsFjap2SKFfcUNyTSl1oKYB+aBY9OeuqXa", new DateTime(2022, 1, 9, 10, 23, 49, 331, DateTimeKind.Utc).AddTicks(3293) });
        }
    }
}
