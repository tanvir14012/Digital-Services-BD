using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Services.Surjopay;
using Digital_Services_BD.Utilities;
using Digital_Services_BD.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Rotativa.AspNetCore;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> logger;
        private readonly ICartOps cartOps;
        private readonly IOrderOps orderOps;
        private readonly IPaymentTransactionOps paymentTransactionOps;
        private readonly IConfiguration configuration;
        private readonly AppDbContext dbContext;
        private readonly ISurjopayService surjopayService;
        private readonly IEmailService emailService;
        private readonly ICompositeViewEngine viewEngine;
        private readonly IEncryptionService encryptionService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CartController(ILogger<CartController> logger, ICartOps cartOps, IOrderOps orderOps,
            IPaymentTransactionOps paymentTransactionOps, IConfiguration configuration, AppDbContext dbContext,
            ISurjopayService surjopayService, IEmailService emailService, ICompositeViewEngine viewEngine,
            IEncryptionService encryptionService, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.cartOps = cartOps;
            this.orderOps = orderOps;
            this.paymentTransactionOps = paymentTransactionOps;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.surjopayService = surjopayService;
            this.emailService = emailService;
            this.viewEngine = viewEngine;
            this.encryptionService = encryptionService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$"))
                    ? Convert.ToInt32(cartIdCookie) : (int?)null;

                var cartView = await cartOps.GetCart(cartId);
                cartView.Message = TempData["Message"]?.ToString() ?? cartView.Message;
                cartView.UserEmail = User.FindFirst(ClaimTypes.Email)?.Value;

                if (cartView != null)
                {
                    if (cartView.IsCreatedNow)
                    {
                        var option = new CookieOptions();
                        option.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Append("CartId", cartView.CartId.ToString(), option);
                    }
                    return View(cartView);
                }
            }
            return View(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Index(int cartId, List<CartItemIdQty> cartItemIdNquantity,
             int? cartItemIdToBeDeleted, List<CartItemBundleIdQty> cartItemBundleIdNquantity, int? cartItemBundleIdToBeDeleted)
        {
            if (ModelState.IsValid)
            {
                if (await cartOps.DoesCartExist(cartId))
                {
                    //Delete item
                    if (cartItemIdToBeDeleted != null)
                    {
                        var cartItem = await cartOps.DeleteCartItemFromCart(cartId, (int)cartItemIdToBeDeleted);
                        if (cartItem == null) //Delete unsuccessful
                        {
                            TempData["Message"] = "Sorry! Some error occurred while deleting the item from your cart. Please try again.";
                        }
                    }
                    else if (cartItemIdNquantity.Count > 0) // Update quantity
                    {
                        foreach (var itemIdQty in cartItemIdNquantity)
                        {
                            await cartOps.UpdateQuantity(itemIdQty.CartItemId, itemIdQty.Quantity);
                        }
                    }
                    //Delete bundle
                    if (cartItemBundleIdToBeDeleted != null)
                    {
                        var isDeleted = await cartOps.DeleteProductItemBundleFromCart(cartId, (int)cartItemBundleIdToBeDeleted);
                        if (!isDeleted)
                        {
                            TempData["Message"] = "Sorry! Some error occurred while deleting the package from your cart. Please try again.";
                        }
                    }
                    else if (cartItemBundleIdNquantity.Count > 0)
                    {
                        foreach (var itemIdQty in cartItemBundleIdNquantity)
                        {
                            await cartOps.UpdateProductItemBundleQuantity(cartId, itemIdQty.ProductItemBundleId, itemIdQty.Quantity);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AddToCart(int itemId, int addToCartQuantity, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$"))
                    ? Convert.ToInt32(cartIdCookie) : -1;

                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var cartItemView = await cartOps.AddCartItemtoCart(cartIdFromCookie, userId, itemId, addToCartQuantity);
                if (cartItemView != null)
                {
                    if (cartItemView.IsCartCreatedWhenAdded)
                    {
                        var cookieOps = new CookieOptions();
                        cookieOps.Expires = DateTime.UtcNow.AddMonths(6);
                        Response.Cookies.Append("CartId", cartItemView.CreatedCartId.ToString(), cookieOps);
                    }
                    if (cartItemView.Message != null)
                    {
                        TempData["Message"] = cartItemView.Message;
                        TempData["AlertClass"] = cartItemView.MessageClass;
                    }
                    else
                    {
                        TempData["Message"] = "Success! The item has been added to your cart.";
                        TempData["AlertClass"] = "alert alert-success alert-dismissible fade show";
                    }
                }
                else
                {
                    TempData["Message"] = "Sorry, the item could not be added to your cart. Please try again later.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                }
                return LocalRedirect(returnUrl);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> BuyNow(string userId2, int itemId2, int buyNowQuantity, string returnUrl2)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$"))
                    ? Convert.ToInt32(cartIdCookie) : -1;
                var cartItemView = await cartOps.AddCartItemtoCart(cartIdFromCookie, userId2, itemId2, buyNowQuantity);
                if (cartItemView != null)
                {
                    if (cartItemView.IsCartCreatedWhenAdded)
                    {
                        var cookieOps = new CookieOptions();
                        cookieOps.Expires = DateTime.UtcNow.AddMonths(6);
                        Response.Cookies.Append("CartId", cartItemView.CreatedCartId.ToString(), cookieOps);
                    }

                    return RedirectToAction("Index", new { userId = userId2 });
                }
                else
                {
                    TempData["Message"] = "Sorry, the item could not be added to your cart. Please try again later.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                    return LocalRedirect(returnUrl2);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AddBundleToCart(int itemId, int addToCartQuantity, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$"))
                    ? Convert.ToInt32(cartIdCookie) : -1;

                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var cartItemView = await cartOps.AddProductItemBundletoCart(cartIdFromCookie, userId, itemId, addToCartQuantity);
                if (cartItemView != null)
                {
                    if (cartItemView.IsCartCreatedWhenAdded)
                    {
                        var cookieOps = new CookieOptions();
                        cookieOps.Expires = DateTime.UtcNow.AddMonths(6);
                        Response.Cookies.Append("CartId", cartItemView.CreatedCartId.ToString(), cookieOps);
                    }
                    if (cartItemView.Message != null)
                    {
                        TempData["Message"] = cartItemView.Message;
                        TempData["AlertClass"] = cartItemView.MessageClass;
                    }
                    else
                    {
                        TempData["Message"] = "Success! The package has been added to your cart.";
                        TempData["AlertClass"] = "alert alert-success alert-dismissible fade show";
                    }
                }
                else
                {
                    TempData["Message"] = "Sorry, the package could not be added to your cart. Please try again later.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                }
                return LocalRedirect(returnUrl);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> BuyBundleNow(string userId2, int itemId2, int buyNowQuantity, string returnUrl2)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$"))
                    ? Convert.ToInt32(cartIdCookie) : -1;
                var cartItemView = await cartOps.AddProductItemBundletoCart(cartIdFromCookie, userId2, itemId2, buyNowQuantity);
                if (cartItemView != null)
                {
                    if (cartItemView.IsCartCreatedWhenAdded)
                    {
                        var cookieOps = new CookieOptions();
                        cookieOps.Expires = DateTime.UtcNow.AddMonths(6);
                        Response.Cookies.Append("CartId", cartItemView.CreatedCartId.ToString(), cookieOps);
                    }

                    return RedirectToAction("Index", new { userId = userId2 });
                }
                else
                {
                    TempData["Message"] = "Sorry, the package could not be added to your cart. Please try again later.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                    return LocalRedirect(returnUrl2);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> EmptyCart(int cartId, string userId)
        {
            var isEmpty = await cartOps.EmptyCart(cartId);
            if (!isEmpty)
            {
                TempData["Message"] = "Sorry! Some error occurred while making your cart empty. Please try again.";
                TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
            }
            return RedirectToAction("Index", new { userId = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Checkout(CartConfirm model)
        {
            var cartViewModel = await cartOps.GetCart(model.CartId);
            if (cartViewModel != null && (cartViewModel.CartItems.Count() + cartViewModel.CartItemBundlesViewModel.Count() > 0))
            {
                //Delete orphan orders (if any)
                await orderOps.DeleteOrphanCartOrders(model.CartId);

                var outOfStockCartItems = await cartOps.GetOutOfStockCartProductItems(model.CartId);
                if (outOfStockCartItems.Any())
                {
                    await cartOps.RemoveOutOfStockItems(model.CartId);
                    TempData["Message"] = "We have updated your cart because of stock unavailability of some items." +
                        " Some items may have been removed or the quantity has been reduced.";
                    TempData["AlertClass"] = "alert alert-info alert-dismissible fade show";
                    return RedirectToAction("Index");
                }

                var order = new Order
                {
                    Id = 0,
                    CartId = model.CartId,
                    CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ConfirmEmail = model.Email,
                    SendOfferInMail = model.SendOffers,
                    PriceCurrency = cartViewModel.PriceCurrency,
                    Subtotal = cartViewModel.Subtotal,
                    GrandTotal = cartViewModel.Total,
                    PromoCode = cartViewModel.PromoCode,
                    PromoCodeDiscount = cartViewModel.PromoCodeDiscount,
                    TaxesAndFees = cartViewModel.TaxesAndFees,
                    Status = OrderStatus.AWAITING,
                    OrderItems = cartViewModel.CartItems.Select(cartItem => new OrderItem
                    {
                        Name = cartItem.ProductItem.Name,
                        Price = cartItem.Price,
                        PriceCurrency = "BDT",
                        ProductItemId = cartItem.ProductItemId,
                        Quantity = cartItem.Quantity,
                        Vat = cartItem.Vat,
                        Discount = cartItem.Discount,
                        Id = 0
                    }).ToList(),
                    OrderProductItemBundles = cartViewModel.CartItemBundlesViewModel.Select(bundle => new OrderProductItemBundle
                    {
                        ProductItemBundleId = bundle.ProductItemBundleId,
                        Quantity = bundle.Quantity,
                        BundlePrice = bundle.BundlePrice,
                        BundleDiscount = bundle.BundleDiscount,
                        PriceCurrency = bundle.PriceCurrency
                    }).ToList(),
                    DiscountTotal = cartViewModel.DiscountTotal

                };
                order = await orderOps.AddOrder(order);
                if (order != null)
                {
                    ViewBag.Locations = GeoLocationBd.GetAll();
                    return View("Payment", order);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Payment(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderFromDb = await orderOps.GetOrder(order.Id);
                if (orderFromDb != null)
                {
                    try
                    {

                        //Save billing info to the order
                        await orderOps.AddBillingInfoToOrder(orderFromDb.Id, order.BillingAddress);

                        string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

                        JObject tokenResp = await surjopayService.InitAndGetToken();
                        var token = tokenResp["token"].ToString();
                        var storeId = (int)tokenResp["store_id"];
                        // CREATING LIST OF POST DATA
                        var postData = new Dictionary<string, dynamic>();
                        float amount = (float)(orderFromDb.GrandTotal + orderFromDb.DiscountTotal);
                        float discount = (float)orderFromDb.DiscountTotal;
                        decimal disPercent = ((100 * orderFromDb.DiscountTotal) / (orderFromDb.GrandTotal + orderFromDb.DiscountTotal));
                        var returnUrlVerificationToken = encryptionService.Encrypt(PasswordUtility.GenerateSecuredGuid());

                        postData.Add("token", token);
                        postData.Add("store_id", storeId);
                        postData.Add("order_id", order.Id.ToString());
                        postData.Add("prefix", "NiluD");
                        postData.Add("amount", amount);
                        postData.Add("discsount_amount", discount);
                        postData.Add("disc_percent", disPercent);
                        postData.Add("currency", "BDT");
                        postData.Add("return_url", baseUrl + $"/cart/summary/{returnUrlVerificationToken}");
                        postData.Add("cancel_url", baseUrl + $"/cart/summary/{returnUrlVerificationToken}");
                        postData.Add("customer_name",
                            $"{orderFromDb.Customer?.FirstName ?? "Anonymous"}{orderFromDb.Customer?.LastName}"
                            .Truncate(200));
                        postData.Add("customer_email", orderFromDb.ConfirmEmail);
                        postData.Add("customer_address",
                            $"{order.BillingAddress?.AddressLineOne ?? "N/A"} {order.BillingAddress?.AddressLineTwo ?? ""}"
                            .Truncate(250));
                        postData.Add("customer_city", order.BillingAddress?.City.Truncate(15) ?? "N/A");
                        postData.Add("customer_state", order.BillingAddress?.State ?? "N/A");
                        postData.Add("customer_postcode", order.BillingAddress?.Zip ?? "N/A");
                        postData.Add("customer_country", order.BillingAddress?.Country ?? "N/A");
                        postData.Add("customer_phone", order.BillingAddress?.Mobile.Truncate(18) ?? "N/A");
                        postData.Add("value1", $"{orderFromDb.CustomerId}");
                        //Send a return url verification so general public can not query others order
                        postData.Add("value2", $"{returnUrlVerificationToken}");
                        postData.Add("client_ip", HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());

                        JObject checkoutResp = await surjopayService.Pay(postData);
                        if (checkoutResp["customer_order_id"].ToString() == order.Id.ToString() &&
                            Convert.ToDouble(checkoutResp["amount"].ToString()) == Convert.ToDouble(amount - discount) &&
                            checkoutResp["currency"].ToString().ToUpper() == "BDT" &&
                            !string.IsNullOrEmpty(checkoutResp["checkout_url"].ToString()))
                        {
                            var transaction = new PaymentTransaction
                            {
                                SurjoPayOrderId = checkoutResp["sp_order_id"].ToString(),
                                OrderId = orderFromDb.Id,
                                Amount = orderFromDb.GrandTotal,
                                Status = "Initiated"
                            };
                            var dbTrnx = await paymentTransactionOps.AddPaymentTransaction(transaction);
                            if (dbTrnx != null)
                            {
                                //Make the cart empty
                                await cartOps.EmptyCart(orderFromDb.CartId);
                                return Redirect(checkoutResp["checkout_url"].ToString());
                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        logger.Log(LogLevel.Error, $"Error in requesting payment: {ex.Message}. {ex?.StackTrace ?? string.Empty}");
                        return RedirectToAction("Index");
                    }

                }

            }
            ViewBag.Message = "Something went wrong. Please try again later.";
            ViewBag.Locations = GeoLocationBd.GetAll();
            return View(order);
        }

        [AllowAnonymous]
        [HttpGet("{verificationToken}")]
        public async Task<IActionResult> Summary([FromRoute] string verificationToken, [FromQuery] string order_id)
        {
            try
            {
                if (!string.IsNullOrEmpty(order_id) && !string.IsNullOrEmpty(verificationToken))
                {
                    JObject tokenResp = await surjopayService.InitAndGetToken();
                    var token = tokenResp["token"].ToString();
                    var transaction = await surjopayService.ValidateOrder(order_id, token);

                    var decryptedUserVerfToken = encryptionService.Decrypt(verificationToken);
                    var decryptedUserVerfToken2 = encryptionService.Decrypt(transaction.UserVerificationToken);
                    //If successful payment, dispatch deliverables
                    if (transaction.SurjoPayCode == 1000 && decryptedUserVerfToken == decryptedUserVerfToken2)
                    {
                        var orderDetails = await dbContext.Orders.AsNoTracking()
                            .FirstOrDefaultAsync(o => o.Id == transaction.OrderId);

                        //if (orderDetails.Status == OrderStatus.PROCESSING)
                        {
                            var pickResult = await orderOps.PickDeliverables(transaction.OrderId);


                            var smtpConfig = await dbContext.SmtpConfigs.AsNoTracking().FirstOrDefaultAsync();
                            var logoLinkedRsrc = new EmailLinkedResource
                            {
                                ContentId = "logo",
                                ContentBytes = System.IO.File.ReadAllBytes(Path.Combine(webHostEnvironment.WebRootPath, "branding",
                                "companyLogo.png")),
                                ContentPath = "/branding/companyLogo.png",
                                ContentType = "image/png"
                            };

                            //PDF invoice
                            ViewData["Shopname"] = configuration["Contact:Name"];
                            ViewData["ShopAddress1"] = configuration["Contact:Address1"];
                            ViewData["ShopAddress2"] = configuration["Contact:Address2"];
                            ViewData["Website"] = configuration["Contact:Website"];
                            ViewData["Phone"] = configuration["Contact:Phone"];
                            ViewData["Email"] = configuration["Contact:Email"];
                            var pdfInvoice = new ViewAsPdf("ExportInvoice", pickResult.Order, ViewData)
                            {
                                FileName = $"Invoice_{pickResult.Order.Transaction.InvoiceId}.pdf",
                                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                            };

                            var templateModel = new OrderEmailTemplate
                            {
                                Order = pickResult.Order,
                                MissingItems = pickResult.UnpickedProducts,
                                Address1 = configuration["Contact:Address1"],
                                Address2 = configuration["Contact:Address2"],
                                RecipeintName = $"{orderDetails.Customer?.FirstName} {orderDetails.Customer?.LastName}",
                                ShopEmail = configuration["Contact:Email"],
                                ShopName = configuration["Contact:Name"],
                                ShopPhone = configuration["Contact:Phone"],
                                Website = configuration["Contact:Website"],
                                EmailLinkedResources = new List<EmailLinkedResource>
                                {
                                    logoLinkedRsrc
                                }
                            };

                            //Order Summary 
                            var email = new Email
                            {
                                FromAddress = smtpConfig?.FromAddress,
                                FromName = configuration["Contact:Name"],
                                Subject = "Order summary",
                                ToAddresses = new List<string> { orderDetails.ConfirmEmail },
                                BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine,
                                    "OrderInvoiceEmailTemplate", templateModel),
                                EmailLinkedResources = new List<EmailLinkedResource>
                                {
                                    logoLinkedRsrc
                                },

                                Attachments = new List<Stream> {
                                    new MemoryStream(await pdfInvoice.BuildFile(ControllerContext))
                                },
                                AttachmentNames = new List<string>
                                {
                                    pdfInvoice.FileName
                                }
                            };
                            await emailService.SendEmailAsync(email);

                            //Order Delivery
                            var deliveryEmail = new Email
                            {
                                FromAddress = smtpConfig?.FromAddress,
                                FromName = configuration["Contact:Name"],
                                Subject = "Order delivery",
                                ToAddresses = new List<string> { orderDetails.ConfirmEmail },
                                BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine,
                                    "OrderDispatchEmailTemplate", templateModel),
                                EmailLinkedResources = new List<EmailLinkedResource>
                                {
                                    logoLinkedRsrc
                                }
                            };
                            await emailService.SendEmailAsync(deliveryEmail);


                        }

                        return View(transaction.Order);
                    }

                }
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Heading = "Order Not Found";
                ViewBag.Message = "The order is not found on the system";
                ViewBag.Action = "Index";
                ViewBag.Controller = "Orders";
                ViewBag.BackText = "Orders";
                return View("NotFound");
            }
            catch (Exception ex)
            {

            }

            ViewBag.Heading = "Incomplete Payment!";
            ViewBag.HeadingClass = "alert-warning";
            ViewBag.Message = "The payment for the order is either canceled or failed.";
            ViewBag.Action1 = "Index";
            ViewBag.Controller1 = "Orders";
            ViewBag.LinkText1 = "Orders";
            return View("AlertMessage");
        }
    }
}
