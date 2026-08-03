using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    public partial class paymentTs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GatewayCurrency",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "IPAddr",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "TrnxType",
                table: "PaymentTransactions");

            migrationBuilder.RenameColumn(
                name: "StatementShow",
                table: "PaymentTransactions",
                newName: "TrnxMethod");

            migrationBuilder.RenameColumn(
                name: "CardType",
                table: "PaymentTransactions",
                newName: "SurjoPayMsg");

            migrationBuilder.RenameColumn(
                name: "CardBrand",
                table: "PaymentTransactions",
                newName: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "SurjoPayOrderId",
                table: "PaymentTransactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "CardNo",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardIssuerCountry",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardIssuerBank",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankTrnxId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PaymentTransactions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInUSD",
                table: "PaymentTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BankStatus",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PaymentTransactions",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PaymentTransactions",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentTransactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RateOfUSD",
                table: "PaymentTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SurjoPayCode",
                table: "PaymentTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "Byu6TcLDWT3ays+YJ7iL3126gHkK4KHon5f7x6bK22x+S3gD5uAIq+UKfSb0/bP4", new DateTime(2021, 12, 29, 8, 36, 14, 126, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_SurjoPayOrderId",
                table: "PaymentTransactions",
                column: "SurjoPayOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_SurjoPayOrderId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "AmountInUSD",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "BankStatus",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "RateOfUSD",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "SurjoPayCode",
                table: "PaymentTransactions");

            migrationBuilder.RenameColumn(
                name: "TrnxMethod",
                table: "PaymentTransactions",
                newName: "StatementShow");

            migrationBuilder.RenameColumn(
                name: "SurjoPayMsg",
                table: "PaymentTransactions",
                newName: "CardType");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "PaymentTransactions",
                newName: "CardBrand");

            migrationBuilder.AlterColumn<string>(
                name: "SurjoPayOrderId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PaymentTransactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CardNo",
                table: "PaymentTransactions",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardIssuerCountry",
                table: "PaymentTransactions",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardIssuerBank",
                table: "PaymentTransactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankTrnxId",
                table: "PaymentTransactions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GatewayCurrency",
                table: "PaymentTransactions",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IPAddr",
                table: "PaymentTransactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrnxType",
                table: "PaymentTransactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EncryptionKeys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "LastUpdated" },
                values: new object[] { "qzDcV5AEPB0zwjy/G6baqaf4ckW22gJmComg8/XFjCFgQI81NaXXeBUP+Kx/uQMm", new DateTime(2021, 12, 28, 19, 1, 39, 158, DateTimeKind.Utc).AddTicks(3885) });
        }
    }
}
