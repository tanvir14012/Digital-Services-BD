using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Logging;
using Digital_Services_BD.Services.Surjopay;
using Wkhtmltopdf.NetCore;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace Digital_Services_BD
{
    public class Startup
    {
        private static readonly IReadOnlyList<CultureInfo> SupportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("bn-BD")
        };

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable runtime compilation only in development mode
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Injecting connection string to AppDbContext constructor by di
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConn"));
            });

            //Use Identity framework for authentication, token etc. with ef core
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
                .AddTokenProvider<Models.EmailTokenProvider<Customer>>("ConfirmEmailTokenProvider");

            //Configure all token lifetime except custom tokens
            services.Configure<DataProtectionTokenProviderOptions>(options => {
                options.TokenLifespan = TimeSpan.FromHours(3);
            });

            //Configure email confirm token lifetime
            services.Configure<Models.EmailTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(3);
            });

            //Configure cookies
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Account/SignIn";
                options.LogoutPath = "/";
                options.AccessDeniedPath = "/Account/Unavailable";
                //Make cookie unaccessible through client side script
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
            });

            //Add  localization services, resource path
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            //Adds support for localized view files(view suffix like: home.fr.cshtml => fr, extension excluded naturally), data annotations
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            //Add Http client factory
            services.AddHttpClient();

            //Add product group, category, item ops
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

            //Add Amazon's aws ses credentials
            services.Configure<AwsSesConfig>(configuration.GetSection("AwsSesConfig"));

            //Authorization policy
            services.AddAuthorization(options => {
                options.AddPolicy("AdminFullAccess", policy => policy.RequireAssertion(context =>
                {
                    return AuthorizePolicyAssertions.AdminFullAccess(context, configuration);
                }));
            });

            //Add SSLCommerze IPN Filter to MVC filters collection
            services.AddScoped<SurjopayIPNIpFilter>(serviceProvider =>
            {
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<SurjopayIPNIpFilter>();

                return new SurjopayIPNIpFilter(
                    configuration["SurjopayConfig:IpAddressSafeListForIPN"], logger);
            });

            //services.AddWkhtmltopdf(); //For localhost, to generate pdf invoices.
            services.AddWkhtmltopdf(System.IO.Path.Combine("wwwroot", "Rotativa")); //For production

            //Lowercase routing
            services.AddRouting(options => {
                options.LowercaseUrls = true;
            });

            //Add data protection
            services.AddDataProtection()
                    .PersistKeysToDbContext<AppDbContext>()
                    .SetApplicationName("Nilu Digital Store");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            //Configure localization middleware, it sets current culture of a request
            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = SupportedCultures.ToList();
                options.SupportedUICultures = SupportedCultures.ToList();
                //options.RequestCultureProviders = new List<IRequestCultureProvider>
                //{
                //   new QueryStringRequestCultureProvider
                //   {
                //       QueryStringKey = "culture",
                //       UIQueryStringKey = "ui-culture"
                //   }
                //};
            });

            app.UseStaticFiles();

            app.UseRouting();

            //Enable user authentication cookie etc.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Configure Rotativa for PDF generation
            RotativaConfiguration.Setup(env.WebRootPath);

            //Create admin account and role
            IdentitySeedData.CreateAdminEntries(app.ApplicationServices, configuration);
        }
    }
}
