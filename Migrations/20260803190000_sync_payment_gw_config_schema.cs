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
    DECLARE @defaultConstraintName sysname;

    SELECT @defaultConstraintName = dc.name
    FROM sys.default_constraints dc
    INNER JOIN sys.columns c
        ON c.default_object_id = dc.object_id
    INNER JOIN sys.tables t
        ON t.object_id = c.object_id
    INNER JOIN sys.schemas s
        ON s.schema_id = t.schema_id
    WHERE s.name = N'dbo'
      AND t.name = N'PaymentGwConfigs'
      AND c.name = N'IsOperational';

    IF @defaultConstraintName IS NOT NULL
    BEGIN
        EXEC(N'ALTER TABLE [dbo].[PaymentGwConfigs] DROP CONSTRAINT [' + @defaultConstraintName + N']');
    END;

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
