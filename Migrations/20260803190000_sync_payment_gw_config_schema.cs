using Digital_Services_BD.Models;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Services_BD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260803190000_sync_payment_gw_config_schema")]
    public partial class sync_payment_gw_config_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.PaymentGwConfigs', 'StoreId') IS NOT NULL
    AND COL_LENGTH('dbo.PaymentGwConfigs', 'Username') IS NULL
BEGIN
    EXEC sp_rename N'dbo.PaymentGwConfigs.StoreId', N'Username', 'COLUMN';
END;

IF COL_LENGTH('dbo.PaymentGwConfigs', 'StoreSecret') IS NOT NULL
    AND COL_LENGTH('dbo.PaymentGwConfigs', 'Password') IS NULL
BEGIN
    EXEC sp_rename N'dbo.PaymentGwConfigs.StoreSecret', N'Password', 'COLUMN';
END;

IF COL_LENGTH('dbo.PaymentGwConfigs', 'IsOperational') IS NOT NULL
BEGIN
    ALTER TABLE [dbo].[PaymentGwConfigs] DROP COLUMN [IsOperational];
END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.PaymentGwConfigs', 'Username') IS NOT NULL
    AND COL_LENGTH('dbo.PaymentGwConfigs', 'StoreId') IS NULL
BEGIN
    EXEC sp_rename N'dbo.PaymentGwConfigs.Username', N'StoreId', 'COLUMN';
END;

IF COL_LENGTH('dbo.PaymentGwConfigs', 'Password') IS NOT NULL
    AND COL_LENGTH('dbo.PaymentGwConfigs', 'StoreSecret') IS NULL
BEGIN
    EXEC sp_rename N'dbo.PaymentGwConfigs.Password', N'StoreSecret', 'COLUMN';
END;

IF COL_LENGTH('dbo.PaymentGwConfigs', 'IsOperational') IS NULL
BEGIN
    ALTER TABLE [dbo].[PaymentGwConfigs] ADD [IsOperational] bit NOT NULL CONSTRAINT [DF_PaymentGwConfigs_IsOperational] DEFAULT CAST(0 AS bit);
END;");
        }
    }
}
