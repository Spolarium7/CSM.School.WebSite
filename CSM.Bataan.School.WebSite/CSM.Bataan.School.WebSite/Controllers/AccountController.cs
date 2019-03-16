using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Infrastructure.Security;
using CSM.Bataan.School.WebSite.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly DefaultDbContext _context;
        protected readonly IConfiguration _config;
        private IHostingEnvironment _env;
        private string emailUserName;
        private string emailPassword;

        public AccountController(DefaultDbContext context, IConfiguration config, IHostingEnvironment env)
        {
            _context = context;
            _config = config;
            var emailConfig = this._config.GetSection("Email");
            emailUserName = (emailConfig["Username"]).ToString();
            emailPassword = (emailConfig["Password"]).ToString();
            _env = env;
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
                Role = Role.User
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

        [ValidateRecaptcha]
        [HttpPost, Route("account/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                        var roles = this._context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.Role).ToList();
                        var groupIds = this._context.UserGroups.Where(ug => ug.UserId == user.Id).Select(ug => ug.GroupId).ToList();
                        var groups = this._context.Groups.Where(g => groupIds.Contains(g.Id.Value)).ToList();

                        WebUser.SetUser(user, roles, groups);
                        await this.SignIn();
                        return RedirectPermanent("~/account/change-password");
                    }
                    else if (user.LoginStatus == Infrastructure.Data.Enums.LoginStatus.Active)
                    {
                        user.LoginTrials = 0;
                        user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.Active;
                        this._context.Users.Update(user);
                        this._context.SaveChanges();

                        //SignIn

                        var roles = this._context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.Role).ToList();
                        var groupIds = this._context.UserGroups.Where(ug => ug.UserId == user.Id).Select(ug => ug.GroupId).ToList();
                        var groups = this._context.Groups.Where(g => groupIds.Contains(g.Id.Value)).ToList();

                        WebUser.SetUser(user, roles, groups);
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

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await this.SignOut();
            return RedirectToAction("login");
        }

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("account/landing")]
        public IActionResult Landing()
        {
            return View();
        }

        [HttpGet, Route("account/forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [ValidateRecaptcha]
        [HttpPost, Route("account/forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = this._context.Users.FirstOrDefault(u =>
                    u.EmailAddress.ToLower() == model.EmailAddress.ToLower());

            if (user != null)
            {
                var newPassword = RandomString(6);
                user.Password = BCryptHelper.HashPassword(newPassword, BCryptHelper.GenerateSalt(9));
                user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.NeedsToChangePassword;

                this._context.Users.Update(user);
                this._context.SaveChanges();

                this.EmailSendNow(
                            ForgotPasswordEmailTemplate(newPassword, user.FullName),
                            user.EmailAddress,
                            user.FullName,
                            "CSM Bataan WebSite - Forgot Password"
                );

                return RedirectPermanent("~/account/login");
            }

            return View();
        }

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("account/change-password")]
        public IActionResult ChangePassword()
        {
            var userId = WebUser.UserId;
            return View();
        }

        [Authorize(Policy = "SignedIn")]
        [HttpPost, Route("account/change-password")]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (model.NewPassword != model.ConfirmNewPassword)
            {
                ModelState.AddModelError("", "New Password does not match Confirm New Password");
                return View();
            }


            var user = this._context.Users.FirstOrDefault(u =>
                    u.Id == WebUser.UserId);

            if (user != null)
            {
                if (BCryptHelper.CheckPassword(model.OldPassword, user.Password) == false)
                {
                    ModelState.AddModelError("", "Incorrect old Password.");
                    return View();
                }

                user.Password = BCryptHelper.HashPassword(model.NewPassword, BCryptHelper.GenerateSalt(8));
                user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.Active;

                this._context.Users.Update(user);
                this._context.SaveChanges();

                return RedirectPermanent("/home/index");
            }

            return View();
        }

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("account/update-profile")]
        public IActionResult UpdateProfile()
        {
            return View(new UpdateProfileViewModel()
            {
                FirstName = WebUser.FirstName,
                LastName = WebUser.LastName,
                UserId = WebUser.UserId.Value,
                PhoneNumber = WebUser.PhoneNumber,
                Gender = WebUser.Gender
            });
        }

        [Authorize(Policy = "SignedIn")]
        [HttpPost, Route("account/update-profile")]
        public IActionResult UpdateProfile(UpdateProfileViewModel model)
        {
            var user = this._context.Users.FirstOrDefault(u =>
                    u.Id == WebUser.UserId);

            if (user != null)
            {
                user.PhoneNumber = model.PhoneNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;

                this._context.Users.Update(user);
                this._context.SaveChanges();

                var roles = this._context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.Role).ToList();
                var groupIds = this._context.UserGroups.Where(ug => ug.UserId == user.Id).Select(ug => ug.GroupId).ToList();
                var groups = this._context.Groups.Where(g => groupIds.Contains(g.Id.Value)).ToList();

                WebUser.SetUser(user, roles, groups);

                return RedirectPermanent("/account/update-profile");
            }

            return View();
        }

        [HttpGet, Route("/account/profile-image/{guid}/{userId}.png")]
        public IActionResult ProfilePicture(string guid, string userId)
        {
            var fullFilePath = this.GetFullFilePath(userId + ".png");

            var image = System.IO.File.OpenRead(fullFilePath);

            return File(image, "image/jpeg");
        }

        private string GetFullFilePath(string filename)
        {
            var dirPath = _env.WebRootPath + "/users/" + filename;
            if (!System.IO.File.Exists(dirPath))
            {
                return _env.WebRootPath + "/users/default.png";
            }

            return dirPath;
        }


        [HttpPost, Route("/account/update-profile-image")]
        public async Task<IActionResult> UpdateProfileImage(UpdateProfileImageViewModel model)
        {
            var fileSize = model.ImageFile.Length;
            if ((fileSize / 1048576.0) > 2)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 2mb.");
                return View(model);
            }

            if (model.ImageFile.ContentType != "image/jpeg" && model.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the profile pictures.");
                return View(model);
            }

            var dirPath = _env.WebRootPath + "/users/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var filePath = dirPath + "/" + WebUser.UserId + ".png";
            if (model.ImageFile.Length > 0)
            {

                byte[] bytes = await FileBytes(model.ImageFile.OpenReadStream());             
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    image.Mutate(x => x.Resize(150, 150));
                    image.Save(filePath);
                }
            }

            return RedirectPermanent("~/account/update-profile");
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
            WebUser.Roles = new List<Role>();
            WebUser.Groups = new List<Group>();

            HttpContext.Session.Clear();
        }

        #region Helpers
        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<byte[]> FileBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        #endregion

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

        private string ForgotPasswordEmailTemplate(string password, string recepientName)
        {
            return EmailTemplateLayout(@"<tr>
                        <td><h3 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px;'>Greetings from CSM Bataan Website!</h3></td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>
                                You asked us to reset your password.<br />.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:20px 30px 0; text-align:center;'>
                                <strong>Use this one-time password so you can login:</strong>
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
                                    <td><p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0; font-size:12px; color:#999; text-align:center;'>&copy; " + @DateTime.Now.Year + @" COLLEGE OF SUBIC MONTESSORI - DINALUPIHAN AND LINCOLN HEIGHTS | All Rights Reserved</p></td>         
                                </tr>
                        </table>
                    </body>
                    </html>";
        }
        #endregion
        #endregion
    }
}