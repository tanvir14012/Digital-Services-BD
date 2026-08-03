using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

using Digital_Services_BD.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Digital_Services_BD.Seeding
{
    internal static class ApplicationSnapshotSeeder
    {
        private const string SeedName = "csharp-snapshot-v1";

        public static void Seed(IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            ILogger logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("SnapshotSeed");
            AppDbContext dbContext = services.GetRequiredService<AppDbContext>();

            if (!dbContext.Database.CanConnect())
            {
                logger.LogWarning("Skipping snapshot seed because SQL Server is unavailable.");
                return;
            }

            DbConnection connection = dbContext.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using IDbContextTransaction transaction = dbContext.Database.BeginTransaction();
            DbTransaction dbTransaction = transaction.GetDbTransaction();

            EnsureSeedHistoryTable(connection, dbTransaction);
            if (SeedAlreadyApplied(connection, dbTransaction))
            {
                transaction.Commit();
                logger.LogInformation("Skipping snapshot seed because {SeedName} was already applied.", SeedName);
                return;
            }

            SetAllConstraintsEnabled(connection, dbTransaction, enabled: false);
            DeleteAllSeedTargetData(connection, dbTransaction);

            IReadOnlyDictionary<string, SeedTableMetadata> tableMetadata = LoadTableMetadata(connection, dbTransaction);

            int appliedBatchCount = 0;
            foreach (SeedInsertBatch batch in SnapshotSeedData.Batches)
            {
                if (ApplyBatch(connection, dbTransaction, tableMetadata, batch))
                {
                    appliedBatchCount++;
                }
            }

            SetAllConstraintsEnabled(connection, dbTransaction, enabled: true);
            InsertSeedMarker(connection, dbTransaction);

            transaction.Commit();
            logger.LogInformation("Applied snapshot seed {SeedName} with {AppliedBatchCount} batches.", SeedName, appliedBatchCount);
        }

        private static bool ApplyBatch(
            DbConnection connection,
            DbTransaction transaction,
            IReadOnlyDictionary<string, SeedTableMetadata> tableMetadata,
            SeedInsertBatch batch)
        {
            if (!tableMetadata.TryGetValue(batch.TableName, out SeedTableMetadata? metadata))
            {
                return false;
            }

            // Validate that all rows have the expected number of columns
            int expectedColumnCount = batch.Columns.Length;
            foreach (string[] row in batch.Rows)
            {
                if (row.Length != expectedColumnCount)
                {
                    throw new InvalidOperationException(
                        $"Seed data integrity error for table '{batch.TableName}': " +
                        $"Expected {expectedColumnCount} columns but found a row with {row.Length} values. " +
                        $"The seed data file may be corrupted or incomplete. Please regenerate the seed data.");
                }
            }

            List<int> applicableIndexes = new();
            for (int index = 0; index < batch.Columns.Length; index++)
            {
                if (metadata.ColumnNames.Contains(batch.Columns[index]))
                {
                    applicableIndexes.Add(index);
                }
            }

            if (applicableIndexes.Count == 0)
            {
                return false;
            }

            string[] applicableColumns = applicableIndexes.Select(index => batch.Columns[index]).ToArray();
            bool useIdentityInsert = metadata.IdentityColumn is not null
                && applicableColumns.Contains(metadata.IdentityColumn, StringComparer.OrdinalIgnoreCase);

            if (useIdentityInsert)
            {
                ExecuteNonQuery(connection, transaction, $"SET IDENTITY_INSERT [dbo].[{batch.TableName}] ON;");
            }

            foreach (string[] row in batch.Rows)
            {
                string valueList = string.Join(", ", applicableIndexes.Select(index => row[index]));
                string columnList = string.Join(", ", applicableColumns.Select(column => $"[{column}]"));
                ExecuteNonQuery(
                    connection,
                    transaction,
                    $"INSERT INTO [dbo].[{batch.TableName}] ({columnList}) VALUES ({valueList});");
            }

            if (useIdentityInsert)
            {
                ExecuteNonQuery(connection, transaction, $"SET IDENTITY_INSERT [dbo].[{batch.TableName}] OFF;");
            }

            return true;
        }

        private static IReadOnlyDictionary<string, SeedTableMetadata> LoadTableMetadata(DbConnection connection, DbTransaction transaction)
        {
            Dictionary<string, SeedTableMetadata> metadata = new(StringComparer.OrdinalIgnoreCase);

            using DbCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = @"
SELECT
    t.[name] AS TableName,
    c.[name] AS ColumnName,
    CAST(COLUMNPROPERTY(c.[object_id], c.[name], 'IsIdentity') AS int) AS IsIdentity
FROM sys.tables t
INNER JOIN sys.schemas s
    ON s.[schema_id] = t.[schema_id]
INNER JOIN sys.columns c
    ON c.[object_id] = t.[object_id]
WHERE s.[name] = N'dbo'
  AND t.is_ms_shipped = 0
ORDER BY t.[name], c.column_id;";

            using DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tableName = reader.GetString(0);
                string columnName = reader.GetString(1);
                bool isIdentity = reader.GetInt32(2) == 1;

                if (!metadata.TryGetValue(tableName, out SeedTableMetadata? table))
                {
                    table = new SeedTableMetadata();
                    metadata.Add(tableName, table);
                }

                table.ColumnNames.Add(columnName);
                if (isIdentity)
                {
                    table.IdentityColumn = columnName;
                }
            }

            return metadata;
        }

        private static void EnsureSeedHistoryTable(DbConnection connection, DbTransaction transaction)
        {
            ExecuteNonQuery(connection, transaction, @"
IF OBJECT_ID(N'dbo.__SeedScripts', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.__SeedScripts
    (
        ScriptName NVARCHAR(260) NOT NULL PRIMARY KEY,
        AppliedOn DATETIME2 NOT NULL CONSTRAINT DF___SeedScripts_AppliedOn DEFAULT SYSUTCDATETIME()
    );
END");
        }

        private static bool SeedAlreadyApplied(DbConnection connection, DbTransaction transaction)
        {
            using DbCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT COUNT(1) FROM dbo.__SeedScripts WHERE ScriptName = @scriptName;";

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@scriptName";
            parameter.Value = SeedName;
            command.Parameters.Add(parameter);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        private static void InsertSeedMarker(DbConnection connection, DbTransaction transaction)
        {
            using DbCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO dbo.__SeedScripts (ScriptName) VALUES (@scriptName);";

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@scriptName";
            parameter.Value = SeedName;
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();
        }

        private static void SetAllConstraintsEnabled(DbConnection connection, DbTransaction transaction, bool enabled)
        {
            string commandVerb = enabled ? "WITH CHECK CHECK" : "NOCHECK";

            ExecuteNonQuery(connection, transaction, $@"
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'ALTER TABLE '
    + QUOTENAME(SCHEMA_NAME([schema_id]))
    + N'.'
    + QUOTENAME([name])
    + N' {commandVerb} CONSTRAINT ALL;'
    + CHAR(10)
FROM sys.tables
WHERE is_ms_shipped = 0;

EXEC sp_executesql @sql;");
        }

        private static void DeleteAllSeedTargetData(DbConnection connection, DbTransaction transaction)
        {
            ExecuteNonQuery(connection, transaction, @"
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'DELETE FROM '
    + QUOTENAME(SCHEMA_NAME([schema_id]))
    + N'.'
    + QUOTENAME([name])
    + N';'
    + CHAR(10)
FROM sys.tables
WHERE is_ms_shipped = 0
  AND [name] NOT IN (N'__EFMigrationsHistory', N'__SeedScripts');

EXEC sp_executesql @sql;");
        }

        private static void ExecuteNonQuery(DbConnection connection, DbTransaction transaction, string sql)
        {
            using DbCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private sealed class SeedTableMetadata
        {
            public HashSet<string> ColumnNames { get; } = new(StringComparer.OrdinalIgnoreCase);

            public string? IdentityColumn { get; set; }
        }
    }

    internal sealed class SeedInsertBatch
    {
        public SeedInsertBatch(string tableName, string[] columns, string[][] rows)
        {
            TableName = tableName;
            Columns = columns;
            Rows = rows;
        }

        public string TableName { get; }

        public string[] Columns { get; }

        public string[][] Rows { get; }
    }
}
