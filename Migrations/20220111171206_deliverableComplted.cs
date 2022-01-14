using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class deliverableComplted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Deliverables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "DbieFWw3PA6GsnHxBxE8Yzxgk3s4oAcruXDMzfxnOLh3O9bS3M6GcSOsMBPYvwhf", new DateTime(2022, 1, 11, 17, 12, 5, 298, DateTimeKind.Utc).AddTicks(490) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Deliverables");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "DXDvxHEYGkFHu8o9P18rivDO9Y2/2lmFY3PAT0DRoTiU7SKN1Ej/bGdIt7LTBwMN", new DateTime(2022, 1, 10, 14, 3, 35, 53, DateTimeKind.Utc).AddTicks(1898) });
        }
    }
}
