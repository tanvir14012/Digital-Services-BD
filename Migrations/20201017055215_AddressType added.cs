using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class AddressTypeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHomeOrBilling",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Addresses");

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeOrBilling",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
