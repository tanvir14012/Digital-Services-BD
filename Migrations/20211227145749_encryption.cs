using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class encryption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "EncryptionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptionKeys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EncryptionKeys",
                columns: new[] { "Id", "Key", "LastUpdated" },
                values: new object[] { 1, "A7DbL0PCHB9vKEWsGgh77w8jglqvtEN0fnM5Jdy3wZSyBq2xyVTj6mBSZVgDRBnE", new DateTime(2021, 12, 27, 14, 57, 48, 903, DateTimeKind.Utc).AddTicks(5708) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncryptionKeys");

            migrationBuilder.AddColumn<bool>(
                name: "IsOperational",
                table: "PaymentGwConfigs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
