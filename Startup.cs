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

namespace Digital_Services_BD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Injecting connection string to AppDbContext constructor by di
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConn"));
            });
            //Enable no-access to every controller if user is not logged in, except [AllowAnynomous] by this filter
            services.AddMvc(options =>
            {
                //var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                //options.Filters.Add(new AuthorizeFilter(policy));
            });
            //Use Identity sytem for authentication, token etc. with ef core
            services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //Add  localization services, resource path
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            //Adds support for localized view files(view suffix like: home.fr.cshtml => fr, extension excluded naturally), data annotations
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            //Add product group, category, item ops
            services.AddScoped<IProductGroupOps, ProductGroupOps>();
            services.AddScoped<IProductCategoryOps, ProductCategoryOps>();
            services.AddScoped<IProductItemOps, ProductItemOps>();
            services.AddScoped<IProductSectionOps, ProductSectionOps>();
            services.AddScoped<ICarouselOps, CarouselOps>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            //Configure localization middleware, it sets current culture of a request
            app.UseRequestLocalization(options =>
            {
                var supportedCultures = new List<CultureInfo>
                                {
                                    new CultureInfo("en-US"),
                                    new CultureInfo("bn-BD"),
                                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
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

            app.UseAuthorization();
            //Enable user authentication cookie etc.
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
