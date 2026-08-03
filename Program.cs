using System.Globalization;

using Digital_Services_BD.Models;
using Digital_Services_BD.Seeding;
using Digital_Services_BD.Services;
using Digital_Services_BD.Services.Surjopay;
using Digital_Services_BD.Utilities;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

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
ApplicationSnapshotSeeder.Seed(app.Services);

app.Run();

static void EnsureDatabaseCreated(WebApplication app)
{
    using IServiceScope scope = app.Services.CreateScope();
    AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}
