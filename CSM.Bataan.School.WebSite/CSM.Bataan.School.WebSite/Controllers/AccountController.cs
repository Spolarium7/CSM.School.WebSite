using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Infrastructure.Security;
using CSM.Bataan.School.WebSite.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly DefaultDbContext _context;
        protected readonly IConfiguration _config;
        private string emailUserName;
        private string emailPassword;

        public AccountController(DefaultDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            var emailConfig = this._config.GetSection("Email");
            emailUserName = (emailConfig["Username"]).ToString();
            emailPassword = (emailConfig["Password"]).ToString();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateRecaptcha]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return View(model);
            }

            var duplicate = this._context.Users.FirstOrDefault(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower());

            if (duplicate != null)
            {
                return View(model);
            }
            var registrationCode = RandomString(8);
        
            User user = new User()
            {
                EmailAddress = model.EmailAddress.ToLower(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(9)),
                Gender = model.Gender,
                LoginStatus = Infrastructure.Data.Enums.LoginStatus.Unverified,
                LoginTrials = 0,
                RegistrationCode = registrationCode,
                Id = Guid.NewGuid(),
            };

            this._context.Users.Add(user);

            this._context.UserRoles.Add(new UserRole() {
                UserId = user.Id.Value,
                Role = model.Role
            });

            //add to public group
            this._context.UserGroups.Add(new UserGroup()
            {
                UserId = user.Id.Value,
                GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
            });

            this._context.SaveChanges();

            //Send email
            this.EmailSendNow(
                        WelcomeEmailTemplate(registrationCode, user.FullName),
                        model.EmailAddress,
                        user.FullName,
                        "Welcome to CSM Bataan Website!!!"
            );

            return RedirectToAction("verify");
        }

        [HttpGet, Route("account/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("account/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = this._context.Users.FirstOrDefault(u =>
                u.EmailAddress.ToLower() == model.EmailAddress.ToLower());

            if (user != null)
            {
                if (BCrypt.BCryptHelper.CheckPassword(model.Password, user.Password))
                {
                    if (user.LoginStatus == Infrastructure.Data.Enums.LoginStatus.Locked)
                    {
                        ModelState.AddModelError("", "Your account has been locked please contact an Administrator.");
                        return View();
                    }
                    else if (user.LoginStatus == Infrastructure.Data.Enums.LoginStatus.Unverified)
                    {
                        ModelState.AddModelError("", "Please verify your account first.");
                        return View();
                    }
                    else if (user.LoginStatus == Infrastructure.Data.Enums.LoginStatus.NeedsToChangePassword)
                    {
                        user.LoginTrials = 0;
                        user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.Active;
                        this._context.Users.Update(user);
                        this._context.SaveChanges();

                        //SignIn
                        WebUser.SetUser(user);
                        await this.SignIn();
                        return RedirectToAction("change-password");
                    }
                    else if (user.LoginStatus == Infrastructure.Data.Enums.LoginStatus.Active)
                    {
                        user.LoginTrials = 0;
                        user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.Active;
                        this._context.Users.Update(user);
                        this._context.SaveChanges();

                        //SignIn
                        WebUser.SetUser(user);
                        await this.SignIn();
                        return RedirectPermanent("/account/landing");
                    }
                }
                else
                {
                    user.LoginTrials = user.LoginTrials + 1;

                    if (user.LoginTrials >= 3)
                    {
                        ModelState.AddModelError("", "Your account has been locked please contact an Administrator.");
                        user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.Locked;
                    }

                    this._context.Users.Update(user);
                    this._context.SaveChanges();

                    ModelState.AddModelError("", "Invalid Login.");
                    return View();
                }
            }

            ModelState.AddModelError("", "Invalid Login.");
            return View();

        }

        [HttpGet, Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await this.SignOut();
            return RedirectToAction("login");
        }

        [HttpGet, Route("account/landing")]
        public IActionResult Landing()
        {
            return View();
        }

        private async Task SignIn()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, WebUser.UserId.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
        }

        private async Task SignOut()
        {
            await HttpContext.SignOutAsync();

            WebUser.EmailAddress = string.Empty;
            WebUser.FirstName = string.Empty;
            WebUser.LastName = string.Empty;
            WebUser.UserId = null;

            HttpContext.Session.Clear();
        }

        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region Notifications
        #region Email
        private void EmailSendNow(string message, string messageTo, string messageName, string emailSubject)
        {
            var fromAddress = new MailAddress(emailUserName, "CSM Bataan Apps");
            string body = message;


            ///https://support.google.com/accounts/answer/6010255?hl=en
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, emailPassword),
                Timeout = 20000
            };

            var toAddress = new MailAddress(messageTo, messageName);

            smtp.Send(new MailMessage(fromAddress, toAddress)
            {
                Subject = emailSubject,
                Body = body,
                IsBodyHtml = true
            });
        }

        private string ResetPasswordEmailTemplate(string password, string recepientName)
        {
            return EmailTemplateLayout(@"<tr>
                        <td><h3 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px;'>Welcome to CSM Bataan Website!</h3></td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>
                                Your password has been reset by an Admin.<br />.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:20px 30px 0; text-align:center;'>
                                <strong>Your one-time password is:</strong>
                            </p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif;color:#FF9046; font-weight:700; font-size:32px; text-align:center; margin:0;'>
                                " + password + @"
                            </p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>Please change your password once logged in.</p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:15px 30px 30px; text-align:center;'>
                                <span style='font-size:12px; color:#999;'>
                                    (Please do not reply this is a system generated email)
                                </span>
                            </p>
                        </td>
                    </tr>", recepientName, "CSM Bataan Website - Password Reset");
        }

        private string WelcomeEmailTemplate(string registrationCode, string recepientName)
        {
            return EmailTemplateLayout(@"<tr>
                        <td><h3 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px;'>Welcome to CSM Bataan Website!</h3></td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:20px 30px 0; text-align:center;'>
                                <strong>Please use this registration code to activate your account :</strong>
                            </p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif;color:#FF9046; font-weight:700; font-size:32px; text-align:center; margin:0;'>
                                " + registrationCode + @"
                            </p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>You may activate your account <a href=\'\#\'>here</a>.</p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>Please change your password once logged in.</p>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:15px 30px 30px; text-align:center;'>
                                <span style='font-size:12px; color:#999;'>
                                    (Please do not reply this is a system generated email)
                                </span>
                            </p>
                        </td>
                    </tr>", recepientName, "Welcome to CSM Bataan Website");
        }

        private string EmailTemplateLayout(string message, string recepientName, string title)
        {
            return @"<!doctype html>
                        <html>
                        <head>
                            <meta charset='utf-8'>
                            <title>" + title + @"</title>
                        </head>
                        <body style='background:#DDD; margin:0; padding:20px 0;'>
                            <a href='#' target='_blank'>
                                <p style='margin:0 auto; width:600px;'><img src='http://oi66.tinypic.com/29z98a1.jpg' width='600' height='140' /></p>
                            </a>
                            <table style='background:#FFF; width:600px; margin:0 auto;'>
                                <tr>
                                    <td>
                                        <h4 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px 30px 0;'>Dear <i>" + recepientName + @"</i>,</h4>
                                    </td>
                                </tr>
                                " + message + @"
                                <tr>
                                    <td>
                                        <h4 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px 30px 0;'>Kind Regards,</h4>
                                        <p style='margin:0 30px 30px;'>CSM Bataan Apps Team</p>
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td><p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0; font-size:12px; color:#999; text-align:center;'>&copy; " + @DateTime.Now.Year + @" GOSHEN JIMENEZ | All Rights Reserved</p></td>         
                                </tr>
                        </table>
                    </body>
                    </html>";
        }
        #endregion
        #endregion
    }
}