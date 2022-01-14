using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;

namespace Digital_Services_BD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService searchService;
        private readonly IProductSectionOps productSectionOps;
        private readonly ICarouselOps carouselOps;
        private readonly IProductItemBundleOps productItemBundleOps;

        public IStringLocalizer<HomeController> Localizer { get; }

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer,
            ISearchService searchService, IProductSectionOps productSectionOps, ICarouselOps carouselOps,
            IProductItemBundleOps productItemBundleOps)
        {
            _logger = logger;
            Localizer = localizer;
            this.searchService = searchService;
            this.productSectionOps = productSectionOps;
            this.carouselOps = carouselOps;
            this.productItemBundleOps = productItemBundleOps;
        }

        public async Task<IActionResult> Index()
        {
            var productSections = await productSectionOps.GetAllProductSectionsWithNavigation();
            foreach(var ps in productSections)
            {
                ps.ProductItems = ps.ProductSectionJoinProductItem
                    .Select(join => join.ProductItem).Distinct().ToList();
            }
            var bundles = await productItemBundleOps.GetAllProductItemBundlesAsync();
            var model = new HomePageItems
            {
                Carousel = await carouselOps.GetFirstCarousel(),
                ProductSections = productSections,
                Bundles = bundles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Language(string culture, string returnUrl)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }

        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Getstarted()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Tos()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Refundpolicy()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Search(SearchView model)
        {
            if(ModelState.IsValid)
            {
                var products = await searchService.SearchProducts(model);
                return View(products);
            }
            return RedirectToAction("Index");
        }
    }
}
