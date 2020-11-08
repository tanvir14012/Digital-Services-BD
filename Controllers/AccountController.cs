using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
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
        private readonly IOptions<AwsSesConfig> awsSesConfig;
        private readonly IEmailService emailService;

        public AccountController(SignInManager<Customer> signInManager, UserManager<Customer> userManager, ILogger<AccountController> logger,
            ICompositeViewEngine viewEngine, IOptions<AwsSesConfig> awsSesConfig, IEmailService emailService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.viewEngine = viewEngine;
            this.awsSesConfig = awsSesConfig;
            this.emailService = emailService;
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

                        //Generate verification token
                        var newUser = await userManager.FindByEmailAsync(model.Email);
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        var verifyLink = Url.Action("VerifyEmail", "Account", new { Identity = newUser.Id, Token = token }, Request.Scheme);
                        var email = new Email
                        {
                            FromAddress = awsSesConfig.Value.SenderAddress,
                            FromName = "Verification",
                            Subject = "Email verification",
                            ToAddresses = new List<string> { model.Email },
                            BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "SignUpEmailConfirmTemplate", verifyLink)
                        };
                        emailService.SendEmailAsync(email);
                        return View("AlertMessage");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        userManager.DeleteAsync(await userManager.FindByEmailAsync(model.Email));
                    }
                }
                else
                {
                    ModelState.AddModelError("Duplicate Email", "An account with the given email already exists. Please try a different email or log in");
                }
            }
            return View(model);
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResendEmailVerification()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResendEmailVerification(ResendEmail emailModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(emailModel.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    //Generate verification token
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var verifyLink = Url.Action("VerifyEmail", "Account", new { Identity = user.Id, Token = token }, Request.Scheme);
                    var email = new Email
                    {
                        FromAddress = awsSesConfig.Value.SenderAddress,
                        FromName = "Verification",
                        Subject = "Email verification",
                        ToAddresses = new List<string> { user.Email },
                        BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "SignUpEmailConfirmTemplate", verifyLink)
                    };
                    emailService.SendEmailAsync(email);
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
                        ViewBag.Heading = "Email is already verified !";
                        ViewBag.HeadingClass = "alert-info";
                        ViewBag.Message = $"The email address {emailModel.Email} is verified. If you face any problem to sign in, please send an email to " +
                            $"support@thecox.xyz describing your issue. Our support team will contact you shortly.";
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
        public async Task<IActionResult> SignIn(SignIn signInModel, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var signInAttempt = await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
                if(signInAttempt.Succeeded)
                {
                    if(! string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
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
                var user = await userManager.FindByEmailAsync(signInModel.Email);
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ResendEmail emailModel) // Reusing ResendEmail model
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(emailModel.Email);
                if (user != null )
                {
                    //Generate password reset token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetLink = Url.Action("ResetPassword", "Account", new { Identity = user.Id, Token = token }, Request.Scheme);
                    var email = new Email
                    {
                        FromAddress = awsSesConfig.Value.SenderAddress,
                        FromName = "Password reset",
                        Subject = "Reset you password",
                        ToAddresses = new List<string> { user.Email },
                        BodyHtmlPart = ConvertRazorToString.RenderRazorViewToString(this, viewEngine, "ResetPasswordEmailTemplate", resetLink)
                    };
                    emailService.SendEmailAsync(email);
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        public async Task<IActionResult> SignOut(string returnUrl ="/")
        {
            await signInManager.SignOutAsync();
            return LocalRedirect(returnUrl);
        }

    }
}
