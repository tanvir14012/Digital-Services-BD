using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;

namespace Digital_Services_BD.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Customer> signInManager;
        private readonly UserManager<Customer> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly ICompositeViewEngine viewEngine;
        private readonly IEmailService emailService;
        private readonly ICartOps cartOps;
        private readonly IConfiguration configuration;
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment webHostingEnvironment;

        public AccountController(SignInManager<Customer> signInManager, UserManager<Customer> userManager, ILogger<AccountController> logger,
            ICompositeViewEngine viewEngine, IEmailService emailService, ICartOps cartOps, IConfiguration configuration, AppDbContext dbContext,
            IWebHostEnvironment webHostingEnvironment)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.viewEngine = viewEngine;
            this.emailService = emailService;
            this.cartOps = cartOps;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.webHostingEnvironment = webHostingEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    var customer = new Customer
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Email,
                        Email = model.Email
                    };
                    var createResult = await userManager.CreateAsync(customer, model.Password);
                    if (createResult.Succeeded)
                    {
                        ViewBag.Heading = "Success !";
                        ViewBag.HeadingClass = "alert-success";
                        ViewBag.Message = "We have sent a confirmation email with a link to " + model.Email +
                            ". Please click on the link to activate your account. You can log in after successful activation";
                        ViewBag.DynamicMarkup = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "EmailNotSentMsg", null);
                        ViewBag.Action1 = "SignIn";
                        ViewBag.Controller1 = "Account";
                        ViewBag.LinkText1 = "Sign In";

                        var newUser = await userManager.FindByEmailAsync(model.Email);

                        //Create cart
                        await cartOps.CreateCart(newUser.Id);

                        //Generate verification token
                        var smtpConfig = await dbContext.SmtpConfigs.AsNoTracking().FirstOrDefaultAsync();
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        var verifyLink = Url.Action("VerifyEmail", "Account", new { Identity = newUser.Id, Token = token }, Request.Scheme);
                        var logoLinkedRsrc = new EmailLinkedResource
                        {
                            ContentId = "logo",
                            ContentBytes = System.IO.File.ReadAllBytes(Path.Combine(webHostingEnvironment.WebRootPath, "branding",
                              "companyLogo.png")),
                            ContentPath = "/branding/companyLogo.png",
                            ContentType = "image/png"
                        };
                        var tempModel = new VerifyEmail
                        {
                            Address1 = configuration["Contact:Address1"],
                            Address2 = configuration["Contact:Address2"],
                            RecipeintName = $"{newUser.FirstName} {newUser.LastName}",
                            ShopEmail = configuration["Contact:Email"],
                            ShopName = configuration["Contact:Name"],
                            ShopPhone = configuration["Contact:Phone"],
                            VerificationTokenUrl = verifyLink,
                            Website = configuration["Contact:Website"],
                            EmailLinkedResources = new List<EmailLinkedResource>
                            {
                                logoLinkedRsrc
                            }
                        };

                        var email = new Email
                        {
                            FromAddress = smtpConfig?.FromAddress,
                            FromName = configuration["Contact:Name"],
                            Subject = "Email verification",
                            ToAddresses = new List<string> { model.Email },
                            BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "SignUpEmailConfirmTemplate", tempModel),
                            EmailLinkedResources = new List<EmailLinkedResource>
                            {
                                logoLinkedRsrc
                            }
                        };
                        await emailService.SendEmailAsync(email);
                        return View("AlertMessage");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        await userManager.DeleteAsync(await userManager.FindByEmailAsync(model.Email));
                    }
                }
                else
                {
                    ModelState.AddModelError("Duplicate Email", "An account with the given email already exists. Please try a different email or log in");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> VerifyEmail(string identity, string token)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(identity);
                var verification = await userManager.ConfirmEmailAsync(user, token);
                if (verification.Succeeded)
                {
                    ViewBag.Heading = "Success !";
                    ViewBag.HeadingClass = "alert-success";
                    ViewBag.Message = "Your email address is verified. You can now sign in.";
                    ViewBag.Action1 = "SignIn";
                    ViewBag.Controller1 = "Account";
                    ViewBag.LinkText1 = "Sign In";
                    return View("AlertMessage");
                }
            }
            ViewBag.Heading = "Sorry !";
            ViewBag.HeadingClass = "alert-danger";
            ViewBag.Message = "Email address verification failed. The link may have expired or the url is incorrect.";
            ViewBag.Action1 = "ResendEmailConfirmation";
            ViewBag.Controller1 = "Account";
            ViewBag.LinkText1 = "Resend email verification link";
            ViewBag.Action2 = "SignUp";
            ViewBag.Controller2 = "Account";
            ViewBag.LinkText2 = "Sign Up";
            return View("AlertMessage");
        }

        [HttpGet]
        public IActionResult ResendEmailVerification()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> ResendEmailVerification(ResendEmail emailModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(emailModel.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    //Generate verification token
                    var smtpConfig = await dbContext.SmtpConfigs.AsNoTracking().FirstOrDefaultAsync();
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var verifyLink = Url.Action("VerifyEmail", "Account", new { Identity = user.Id, Token = token }, Request.Scheme);
                    var tempModel = new VerifyEmail
                    {
                        Address1 = configuration["Contact:Address1"],
                        Address2 = configuration["Contact:Address2"],
                        RecipeintName = $"{user.FirstName} {user.LastName}",
                        ShopEmail = configuration["Contact:Email"],
                        ShopName = configuration["Contact:Name"],
                        ShopPhone = configuration["Contact:Phone"],
                        VerificationTokenUrl = verifyLink,
                        Website = configuration["Contact:Website"]
                    };
                    var email = new Email
                    {
                        FromAddress = smtpConfig.FromAddress,
                        FromName = "Verification",
                        Subject = "Email verification",
                        ToAddresses = new List<string> { user.Email },
                        BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "SignUpEmailConfirmTemplate", tempModel)
                    };
                    await emailService .SendEmailAsync(email);
                    ViewBag.Heading = "Success !";
                    ViewBag.HeadingClass = "alert-success";
                    ViewBag.Message = $"An email with a verfification link is sent to {emailModel.Email}";

                    return View("AlertMessage");
                }
                else
                {
                    if (user == null)
                    {
                        ViewBag.Heading = "Oops !";
                        ViewBag.HeadingClass = "alert-info";
                        ViewBag.Message = $"The email address {emailModel.Email} is not associated with any account. Please sign up to create an account.";

                    }
                    else
                    {
                        ViewBag.Heading = "Email is already verified!";
                        ViewBag.HeadingClass = "alert-info";
                        ViewBag.Message = $"The email address {emailModel.Email} is verified. If you face any problem to sign in, please send an email to " +
                            $"support@niludigital.com describing your issue. Our support team will contact you shortly.";
                    }
                }

            }
            return View(emailModel);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> SignIn(SignIn signInModel, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var signInAttempt = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
                var user = await userManager.FindByEmailAsync(signInModel.Email);

                if (signInAttempt.Succeeded)
                {
                    // Merge carts if applicable
                    string cartIdCookie = Request.Cookies["CartId"];
                    int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                    if (cartId != null)
                    {
                        var cart = await cartOps.MergeCarts((int)cartId, user.Id);
                        if(cart != null)
                        {
                            await cartOps.RemoveOutOfStockItems(cart.Id);
                            AddCartCookie(cart.Id);
                        }
                    }
                    else
                    {
                        var cart = await cartOps.CreateCart(user.Id);
                        AddCartCookie(cart.Id);
                    }

                    
                    if (! string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if(signInAttempt.IsLockedOut) // If account locked for too many failed logins
                {
                    ViewBag.Heading = "Account locked !";
                    ViewBag.HeadingClass = "alert-warning";
                    ViewBag.Message = $"Your account has been locked because of too many failed sign in attempts." +
                        $" Please wait an hour and try again later. You can reset your password in order to gain immediate access to your account.";
                    ViewBag.Action1 = "ForgotPassword";
                    ViewBag.Controller1 = "Account";
                    ViewBag.LinkText1 = "Reset password";
                    return View("AlertMessage");
                }

                if(user != null && ! user.EmailConfirmed)
                {
                    ViewBag.Heading = "Your email address is not verified yet";
                    ViewBag.HeadingClass = "alert-info";
                    ViewBag.Message = $"Please click on the button below to request for email verification";
                    ViewBag.Action1 = "ResendEmailVerification";
                    ViewBag.Controller1 = "Account";
                    ViewBag.LinkText1 = "Verify email";
                }
                ModelState.AddModelError(string.Empty, "You entered incorrect email and password pair");

            }
            
            return View(signInModel);
        }

        public IActionResult Unavailable()
        {
            ViewBag.Heading = "Unavailable !";
            ViewBag.HeadingClass = "alert-info";
            ViewBag.Message = $"The resource you are trying to access requires more privileges";
            return View("AlertMessage");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> ForgotPassword(ResendEmail emailModel) // Reusing ResendEmail model
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(emailModel.Email);
                if (user != null )
                {
                    //Generate password reset token
                    var smtpConfig = await dbContext.SmtpConfigs.AsNoTracking().FirstOrDefaultAsync();
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetLink = Url.Action("ResetPassword", "Account", new { Identity = user.Id, Token = token }, Request.Scheme);
                    var logoLinkedRsrc = new EmailLinkedResource
                    {
                        ContentId = "logo",
                        ContentBytes = System.IO.File.ReadAllBytes(Path.Combine(webHostingEnvironment.WebRootPath, "branding",
                              "companyLogo.png")),
                        ContentPath = "/branding/companyLogo.png",
                        ContentType = "image/png"
                    };
                    var tempModel = new VerifyEmail
                    {
                        Address1 = configuration["Contact:Address1"],
                        Address2 = configuration["Contact:Address2"],
                        RecipeintName = $"{user.FirstName} {user.LastName}",
                        ShopEmail = configuration["Contact:Email"],
                        ShopName = configuration["Contact:Name"],
                        ShopPhone = configuration["Contact:Phone"],
                        VerificationTokenUrl = resetLink,
                        Website = configuration["Contact:Website"],
                        EmailLinkedResources = new List<EmailLinkedResource>
                        {
                            logoLinkedRsrc
                        }
                    };
                    var email = new Email
                    {
                        FromAddress = smtpConfig.FromAddress,
                        FromName = configuration["Contact:Name"],
                        Subject = "Reset you password",
                        ToAddresses = new List<string> { user.Email },
                        BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "ResetPasswordEmailTemplate", tempModel),
                        EmailLinkedResources = new List<EmailLinkedResource>
                        {
                            logoLinkedRsrc
                        }
                    };
                    await emailService.SendEmailAsync(email);
                    ViewBag.Heading = "Success !";
                    ViewBag.HeadingClass = "alert-success";
                    ViewBag.Message = $"An email with a password reset link is sent to {emailModel.Email}";
                    return View("AlertMessage");
                }
                else
                {
                        ViewBag.Heading = "Oops !";
                        ViewBag.HeadingClass = "alert-info";
                        ViewBag.Message = $"The email address {emailModel.Email} is not associated with any account. Please sign up to create an account.";

                }

            }
            return View(emailModel);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string identity, string token)
        {
            var resetPasswordModel = new ResetPassword
            {
                Id = identity,
                Token = token
            };
            return View(resetPasswordModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPasswordModel)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(resetPasswordModel.Id);
                if(user != null)
                {
                    var resetResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
                    if(resetResult.Succeeded)
                    {
                        //Unlock account if it was locked
                        if(await userManager.IsLockedOutAsync(user))
                        {
                            await userManager.SetLockoutEndDateAsync(user, DateTime.UtcNow);
                        }
                        ViewBag.Heading = "Success !";
                        ViewBag.HeadingClass = "alert-success";
                        ViewBag.Message = "Your password is reset successfully.";
                        ViewBag.Action1 = "SignIn";
                        ViewBag.Controller1 = "Account";
                        ViewBag.LinkText1 = "Sign In";
                        return View("AlertMessage");
                    }
                    else
                    {
                        foreach(var error in resetResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                            return View(resetPasswordModel);
                        }
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Some error occurred while trying to reset your password. Please try again later.");
            return View(resetPasswordModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> SignOut(string returnUrl ="/")
        {
            if(signInManager.IsSignedIn(User))
            {
                // Merge carts if applicable
                string cartIdCookie = Request.Cookies["CartId"];
                int? cartId = (cartIdCookie != null && Regex.IsMatch(cartIdCookie, @"^\d{0,2147483647}$")) ? Convert.ToInt32(cartIdCookie) : (int?)null;
                if (cartId != null)
                {
                    var cart = await cartOps.MergeCarts((int)cartId, User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    if (cart != null)
                    {
                        await cartOps.RemoveOutOfStockItems(cart.Id);
                    }
                }

                await signInManager.SignOutAsync();
                Response.Cookies.Delete("CartId");
                return LocalRedirect(returnUrl);
            }

            return Redirect("~/");
            
        }

        private void AddCartCookie(int cartId)
        {
            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Append("CartId", cartId.ToString(), option);
        }

    }
}
