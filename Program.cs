using System.Globalization;
using System.Data.Common;
using System.Text.RegularExpressions;

using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Services.Surjopay;
using Digital_Services_BD.Utilities;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using NLog.Web;

using Rotativa.AspNetCore;

using Wkhtmltopdf.NetCore;

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("bn-BD")
};

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddControllersWithViews().AddRazorRuntimeCompilation();

services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("SqlServerConn"));
});

services.AddIdentity<Customer, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.Tokens.EmailConfirmationTokenProvider = "ConfirmEmailTokenProvider";

    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<Digital_Services_BD.Models.EmailTokenProvider<Customer>>("ConfirmEmailTokenProvider");

services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(3);
});

services.Configure<EmailTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromDays(3);
});

services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/SignIn";
    options.LogoutPath = "/";
    options.AccessDeniedPath = "/Account/Unavailable";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});

services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

services.AddHttpClient();

services.AddScoped<IProductGroupOps, ProductGroupOps>();
services.AddScoped<IProductCategoryOps, ProductCategoryOps>();
services.AddScoped<IProductItemOps, ProductItemOps>();
services.AddScoped<IProductSectionOps, ProductSectionOps>();
services.AddScoped<IProductItemBundleOps, ProductItemBundleOps>();
services.AddScoped<IProductStockOps, ProductStockOps>();
services.AddScoped<ICarouselOps, CarouselOps>();
services.AddScoped<ICartOps, CartOps>();
services.AddScoped<IOrderOps, OrderOps>();
services.AddScoped<IPaymentTransactionOps, PaymentTransactionOps>();
services.AddScoped<IEmailService, EmailService>();
services.AddScoped<ISearchService, SearchService>();
services.AddSingleton<IEncryptionService, EncryptionService>();
services.AddScoped<ISurjopayService, SurjopayService>();

services.Configure<AwsSesConfig>(configuration.GetSection("AwsSesConfig"));

services.AddAuthorization(options =>
{
    options.AddPolicy("AdminFullAccess", policy => policy.RequireAssertion(context =>
    {
        return AuthorizePolicyAssertions.AdminFullAccess(context, configuration);
    }));
});

services.AddScoped<SurjopayIPNIpFilter>(serviceProvider =>
{
    ILogger<SurjopayIPNIpFilter> logger = serviceProvider.GetRequiredService<ILogger<SurjopayIPNIpFilter>>();
    return new SurjopayIPNIpFilter(configuration["SurjopayConfig:IpAddressSafeListForIPN"], logger);
});

services.AddWkhtmltopdf(Path.Combine("wwwroot", "Rotativa"));

services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

services.AddDataProtection()
    .PersistKeysToDbContext<AppDbContext>()
    .SetApplicationName("Nilu Digital Store");

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures.ToList();
    options.SupportedUICultures = supportedCultures.ToList();
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

RotativaConfiguration.Setup(app.Environment.WebRootPath);

EnsureDatabaseCreated(app);
ExecuteSeedSql(app);
SeedIdentityData(app, configuration);

app.Run();

static void EnsureDatabaseCreated(WebApplication app)
{
    using IServiceScope scope = app.Services.CreateScope();
    AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

static void ExecuteSeedSql(WebApplication app)
{
    using IServiceScope scope = app.Services.CreateScope();
    IServiceProvider services = scope.ServiceProvider;
    ILogger logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("DatabaseSeed");
    AppDbContext dbContext = services.GetRequiredService<AppDbContext>();

    string? scriptContent = GetSeedScriptContent(app, out string? seedScriptPath);
    if (seedScriptPath is null)
    {
        logger.LogInformation("Skipping SQL seed because Seed.sql was not found.");
        return;
    }

    if (string.IsNullOrWhiteSpace(scriptContent))
    {
        logger.LogInformation("Skipping SQL seed because Seed.sql is empty.");
        return;
    }

    const string seedScriptName = "Seed.sql";

    DbConnection connection = dbContext.Database.GetDbConnection();
    if (connection.State != System.Data.ConnectionState.Open)
    {
        connection.Open();
    }

    using IDbContextTransaction transaction = dbContext.Database.BeginTransaction();
    DbTransaction dbTransaction = transaction.GetDbTransaction();

    ExecuteNonQuery(connection, dbTransaction, @"
IF OBJECT_ID(N'dbo.__SeedScripts', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.__SeedScripts
    (
        ScriptName NVARCHAR(260) NOT NULL PRIMARY KEY,
        AppliedOn DATETIME2 NOT NULL CONSTRAINT DF___SeedScripts_AppliedOn DEFAULT SYSUTCDATETIME()
    );
END");

    if (SeedScriptAlreadyApplied(connection, dbTransaction, seedScriptName))
    {
        transaction.Commit();
        logger.LogInformation("Skipping SQL seed because {SeedScriptName} was already applied.", seedScriptName);
        return;
    }

    int skippedBatchCount = 0;
    foreach (string batch in Regex.Split(scriptContent, @"^\s*GO\s*(?:--.*)?$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
    {
        string executableBatch = RemoveUnsupportedSeedStatements(batch);
        if (string.IsNullOrWhiteSpace(executableBatch))
        {
            if (!string.IsNullOrWhiteSpace(batch))
            {
                skippedBatchCount++;
            }

            continue;
        }

        ExecuteNonQuery(connection, dbTransaction, executableBatch);
    }

    using DbCommand insertSeedCommand = connection.CreateCommand();
    insertSeedCommand.Transaction = dbTransaction;
    insertSeedCommand.CommandText = "INSERT INTO dbo.__SeedScripts (ScriptName) VALUES (@scriptName);";
    AddParameter(insertSeedCommand, "@scriptName", seedScriptName);
    insertSeedCommand.ExecuteNonQuery();

    transaction.Commit();
    logger.LogInformation("Applied SQL seed from {SeedScriptPath}. Skipped {SkippedBatchCount} database-level batch(es).", seedScriptPath, skippedBatchCount);
}

static void SeedIdentityData(WebApplication app, IConfiguration configuration)
{
    using IServiceScope scope = app.Services.CreateScope();
    IServiceProvider services = scope.ServiceProvider;
    ILogger logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("IdentitySeed");
    AppDbContext dbContext = services.GetRequiredService<AppDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        logger.LogWarning("Skipping identity seed because SQL Server is unavailable.");
        return;
    }

    string? seedScriptContent = GetSeedScriptContent(app, out string? seedScriptPath);
    if (seedScriptPath is not null && SeedScriptSeedsIdentity(seedScriptContent))
    {
        logger.LogInformation("Skipping identity seed because {SeedScriptPath} already seeds ASP.NET Identity data.", seedScriptPath);
        return;
    }

    IdentitySeedData.CreateAdminEntries(services, configuration);
}

static string? GetSeedScriptContent(WebApplication app, out string? seedScriptPath)
{
    string[] candidatePaths =
    {
        Path.Combine(app.Environment.ContentRootPath, "Seed.sql"),
        Path.Combine(AppContext.BaseDirectory, "Seed.sql")
    };

    seedScriptPath = candidatePaths.FirstOrDefault(File.Exists);
    return seedScriptPath is null ? null : File.ReadAllText(seedScriptPath);
}

static bool SeedScriptSeedsIdentity(string? scriptContent)
{
    return !string.IsNullOrWhiteSpace(scriptContent)
        && Regex.IsMatch(
            scriptContent,
            @"INSERT\s+\[dbo\]\.\[(AspNetUsers|AspNetRoles|AspNetUserRoles)\]",
            RegexOptions.IgnoreCase);
}

static string RemoveUnsupportedSeedStatements(string batch)
{
    string sanitizedBatch = Regex.Replace(
        batch,
        @"^\s*USE\s+\[[^\]]+\]\s*$",
        string.Empty,
        RegexOptions.Multiline | RegexOptions.IgnoreCase);

    if (Regex.IsMatch(sanitizedBatch, @"^\s*ALTER\s+DATABASE\s+\[", RegexOptions.IgnoreCase)
        || Regex.IsMatch(sanitizedBatch, @"sp_fulltext_database", RegexOptions.IgnoreCase))
    {
        return string.Empty;
    }

    return sanitizedBatch.Trim();
}

static bool SeedScriptAlreadyApplied(DbConnection connection, DbTransaction transaction, string scriptName)
{
    using DbCommand command = connection.CreateCommand();
    command.Transaction = transaction;
    command.CommandText = "SELECT COUNT(1) FROM dbo.__SeedScripts WHERE ScriptName = @scriptName;";
    AddParameter(command, "@scriptName", scriptName);

    return Convert.ToInt32(command.ExecuteScalar()) > 0;
}

static void ExecuteNonQuery(DbConnection connection, DbTransaction transaction, string sql)
{
    using DbCommand command = connection.CreateCommand();
    command.Transaction = transaction;
    command.CommandText = sql;
    command.ExecuteNonQuery();
}

static void AddParameter(DbCommand command, string name, object value)
{
    DbParameter parameter = command.CreateParameter();
    parameter.ParameterName = name;
    parameter.Value = value;
    command.Parameters.Add(parameter);
}
