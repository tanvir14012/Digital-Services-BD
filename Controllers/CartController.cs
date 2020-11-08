using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> logger;
        private readonly ICartOps cartOps;
        private readonly IOrderOps orderOps;
        private readonly SslCommerzeOps sslCommerzeOps;
        private readonly IPaymentTransactionOps paymentTransactionOps;

        public CartController(ILogger<CartController> logger, ICartOps cartOps, IOrderOps orderOps,
            SslCommerzeOps sslCommerzeOps, IPaymentTransactionOps paymentTransactionOps)
        {
            this.logger = logger;
            this.cartOps = cartOps;
            this.orderOps = orderOps;
            this.sslCommerzeOps = sslCommerzeOps;
            this.paymentTransactionOps = paymentTransactionOps;
        }
        [HttpGet]
        public IActionResult Index([FromQuery] int? userId)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartView = cartOps.GetCart(cartId, userId);
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
        public IActionResult Index(int cartId, List<CartItemIdQty> cartItemIdNquantity,
             int? cartItemIdToBeDeleted, List<CartItemBundleIdQty> cartItemBundleIdNquantity, int? cartItemBundleIdToBeDeleted)
        {
            if (ModelState.IsValid)
            {
                if (cartOps.DoesCartExist(cartId))
                {
                    //Delete item
                    if (cartItemIdToBeDeleted != null)
                    {
                        var cartItem = cartOps.DeleteCartItemFromCart(cartId, (int)cartItemIdToBeDeleted);
                        if (cartItem == null) //Delete unsuccessful
                        {
                            ViewBag.DeleteMsg = "Sorry! Some error occurred while deleting the item from your cart. Please try again.";
                        }
                    }
                    else if (cartItemIdNquantity.Count > 0) // Update quantity
                    {
                        foreach (var itemIdQty in cartItemIdNquantity)
                        {
                            cartOps.UpdateQuantity(itemIdQty.CartItemId, itemIdQty.Quantity);
                        }
                    }
                    //Delete bundle
                    if (cartItemBundleIdToBeDeleted != null)
                    {
                        var isDeleted = cartOps.DeleteProductItemBundleFromCart(cartId, (int)cartItemBundleIdToBeDeleted);
                        if (!isDeleted)
                        {
                            ViewBag.DeleteMsg = "Sorry! Some error occurred while deleting the package from your cart. Please try again.";
                        }
                    }
                    else if (cartItemBundleIdNquantity.Count > 0)
                    {
                        foreach (var itemIdQty in cartItemBundleIdNquantity)
                        {
                            cartOps.UpdateProductItemBundleQuantity(cartId, itemIdQty.ProductItemBundleId, itemIdQty.Quantity);
                        }
                    }
                    var cartView = cartOps.GetCart(cartId, null);
                    if (cartView != null)
                    {
                        return View(cartView);
                    }
                }
            }
            return View(null);
        }

        [HttpPost]
        public IActionResult AddToCart(int? userId, int itemId, int addToCartQuantity, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItemView = cartOps.AddCartItemtoCart(cartIdFromCookie, userId, itemId, addToCartQuantity);
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
                    TempData["Message"] = "Sorry! Some error occurred while adding the item to your cart. Please try again.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                }
                return LocalRedirect(returnUrl);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public IActionResult BuyNow(int? userId2, int itemId2, int buyNowQuantity, string returnUrl2)
        {
            if (ModelState.IsValid)
            {
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartIdFromCookie = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                var cartItem = cartOps.AddCartItemtoCart(cartIdFromCookie, userId2, itemId2, buyNowQuantity);
                if (cartItem != null)
                {
                    return RedirectToAction("Index", new { userId = userId2 });
                }
                else
                {
                    TempData["Message"] = "Sorry! Some error occurred while adding the item to your cart. Please try again.";
                    TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
                    return LocalRedirect(returnUrl2);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public IActionResult EmptyCart(int cartId, int? userId)
        {
            var isEmpty = cartOps.EmptyCart(cartId);
            if (!isEmpty)
            {
                TempData["Message"] = "Sorry! Some error occurred while making your cart empty. Please try again.";
                TempData["AlertClass"] = "alert alert-warning alert-dismissible fade show";
            }
            return RedirectToAction("Index", new { userId = userId });
        }

        [HttpGet]
        public IActionResult Payment(int cartId, string orderConfirmEmail, bool emailOffers)
        {
            var cartViewModel = cartOps.GetCart(cartId, null);
            if (cartViewModel != null)
            {
                var order = new Order
                {
                    CartId = cartId,
                    ConfirmEmail = orderConfirmEmail,
                    SendOfferInMail = emailOffers,
                    PriceCurrency = cartViewModel.PriceCurrency,
                    TotalPrice = cartViewModel.Total
                };
                order = orderOps.AddOrder(order);
                if (order != null)
                {
                    return View(order);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Payment(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderFromDb = orderOps.GetOrder(order.Id);
                if (orderFromDb != null)
                {
                    orderFromDb.Cart = cartOps.GetCart(orderFromDb.CartId, null);
                    orderFromDb.BillingAddress = order.BillingAddress;
                    var transaction = paymentTransactionOps.AddPaymentTransaction(new PaymentTransaction
                    {
                        OrderId = orderFromDb.Id,
                        Amount = orderFromDb.TotalPrice,
                        GatewayCurrency = orderFromDb.PriceCurrency,
                        Status = TransactionStatus.PENDING.ToString(),
                        TrnxType = TransactionType.PURCHASE.ToString(),
                        IPAddr = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                    });
                    if (transaction != null)
                    {
                        orderFromDb.TransactionId = transaction.Id;
                        orderFromDb.Transaction = transaction;
                        var updatedOrder = orderOps.UpdateOrder(orderFromDb);
                        if (updatedOrder != null)
                        {
                            var redirectUrlForPay = sslCommerzeOps.GetOrderPaymentRedirectUrl(updatedOrder);
                            if (redirectUrlForPay != null)
                            {
                                return Redirect(redirectUrlForPay);
                            }
                        }
                    }
                }

            }
            ViewBag.Message = "Something went wrong. Please try again later.";
            return View(order);
        }

        [HttpGet("{id}")]
        public IActionResult Summary(int id)
        {
            if (ModelState.IsValid)
            {
                var order = orderOps.GetOrder(id);
                if (order != null)
                {
                    order.Cart = cartOps.GetCart(order.CartId, null);
                    return View(order);
                }
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SslIPN(IFormCollection fromCollection)
        {
            TransactionResponse response = sslCommerzeOps.GetTransactionResponse(fromCollection);
            logger.LogInformation(JsonConvert.SerializeObject(response));
            if (response.Status == TransactionStatus.VALID)
            {
                if (orderOps.VerifyOrder(response.ValueA, response.TransactionId, response.CurrencyAmount, response.CurrencyType))
                {
                    ValidatedTransaction validatedTransaction = sslCommerzeOps.ValidateTransaction(fromCollection);

                    if (validatedTransaction.Status != ValidationStatus.INVALID_TRANSACTION)
                    {
                        logger.LogInformation(JsonConvert.SerializeObject(validatedTransaction));
                        // Update database as your need
                        paymentTransactionOps.UpdatePaymentTransaction(Int64.Parse(validatedTransaction.TransactionId), validatedTransaction.Status.ToString(),
                            validatedTransaction.RiskTitle, validatedTransaction.CardNumber, validatedTransaction.CardType, validatedTransaction.Currency,
                            validatedTransaction.BankTransactionId, validatedTransaction.CardIssuer, validatedTransaction.CardBrand, validatedTransaction.CardIssuerCountry);
                    } else
                    {
                        paymentTransactionOps.UpdatePaymentTransactionStatus(Int64.Parse(response.TransactionId), validatedTransaction.Status.ToString());
                    }
                }

            }
            else
            {
                if (orderOps.VerifyOrder(response.ValueA, response.TransactionId, response.CurrencyAmount, response.CurrencyType))
                {
                    paymentTransactionOps.UpdatePaymentTransactionStatus(Int64.Parse(response.TransactionId), response.Status.ToString());
                }
            }
            return Ok();
        }
    }
}
