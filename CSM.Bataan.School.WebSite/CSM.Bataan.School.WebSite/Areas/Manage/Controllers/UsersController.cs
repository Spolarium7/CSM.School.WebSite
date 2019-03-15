using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BCrypt;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class UsersController : Controller
    {
        private readonly DefaultDbContext _context;
        protected readonly IConfiguration _config;
        private string emailUserName;
        private string emailPassword;
        private string smsEndpoint;
        private string smsApiKey;

        public UsersController(DefaultDbContext context, IConfiguration iConfiguration)
        {
            _context = context;
            this._config = iConfiguration;
            var emailConfig = this._config.GetSection("Email");
            emailUserName = (emailConfig["Username"]).ToString();
            emailPassword = (emailConfig["Password"]).ToString();

            var smsConfig = this._config.GetSection("SMS");
            smsEndpoint = (smsConfig["Endpoint"]).ToString();
            smsApiKey = (smsConfig["ApiKey"]).ToString();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users")]
        [HttpGet, Route("manage/users/index")]
        public IActionResult Index(int pageSize = 5, int pageIndex = 1, string keyword = "", string status = "Active")
        {
            Enum.TryParse(status, out LoginStatus loginStatus); ;

            Page<User> result = new Page<User>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<User> userQuery = (IQueryable<User>)this._context.Users.Where(u => u.LoginStatus == loginStatus);

            if (string.IsNullOrEmpty(keyword) == false)
            {
                userQuery = userQuery.Where(u => u.FirstName.Contains(keyword)
                                            || u.LastName.Contains(keyword)
                                            || u.EmailAddress.Contains(keyword));
            }

            long queryCount = userQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<User> users = userQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                Users = result,
                Status = loginStatus
            });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users/invite")]
        public IActionResult Invite()
        {
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/users/invite")]
        public IActionResult Invite(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("index");

            var user = this._context.Users.FirstOrDefault(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower());

            if (user == null)
            {
                var password = RandomString(8);
                var regCode = RandomString(8);

                user = new User()
                {
                    Id = Guid.NewGuid(),
                    EmailAddress = model.EmailAddress,
                    Password = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt(9)),
                    RegistrationCode = regCode,
                    PhoneNumber = model.PhoneNumber,
                    LoginStatus = Infrastructure.Data.Enums.LoginStatus.NeedsToChangePassword,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender
                };
                this._context.Users.Add(user);

                this._context.UserRoles.Add(new UserRole()
                {
                    UserId = user.Id.Value,
                    Role = model.Role                    
                });

                this._context.UserGroups.Add(new UserGroup()
                {
                    UserId = user.Id.Value,
                    GroupId = Guid.Parse("bcc412a8-9169-489b-b579-301186947a19")
                });

                this._context.SaveChanges();

                this.EmailSendNow(
                            WelcomeEmailTemplate(password, user.FullName, model.Role.ToString()),
                            model.EmailAddress,
                            user.FullName,
                            "Welcome to CSM Bataan Website!!!"
                );

                //this.SMSSendNow("Welcome to CSM Bataan Website! You have been invited as a " + model.Role.ToString() + ". Please use this one-time password : " + password + " to login.", user.PhoneNumber);
            }

            return RedirectToAction("index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users/change-status/{status}/{userId}")]
        public IActionResult ChangeStatus(string status, Guid? userId)
        {
            var loginStatus = (LoginStatus)Enum.Parse(typeof(LoginStatus), status, true);
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                user.LoginStatus = loginStatus;
                this._context.Users.Update(user);
                this._context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users/reset-password/{userId}")]
        public IActionResult ResetPassword(Guid? userId)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var password = RandomString(8);

                user.Password = password;
                user.LoginStatus = Infrastructure.Data.Enums.LoginStatus.NeedsToChangePassword;
                this._context.Users.Update(user);
                this._context.SaveChanges();

                this.EmailSendNow(
                            ResetPasswordEmailTemplate(password, user.FullName),
                            user.EmailAddress,
                            user.FullName,
                            "CSM Bataan Website - Password Reset"
                );

                //this.SMSSendNow("Your password has been reset by an Admin. Please use this one-time password : " + password + " to login to the system.", user.PhoneNumber);
            }

            return RedirectToAction("index");
        }

        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users/delete/{userId}")]
        public IActionResult Delete(Guid? userId)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/users/update-profile/{userId}")]
        public IActionResult UpdateProfile(Guid? userId)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return View(
                    new UpdateProfileViewModel()
                    {
                        UserId = userId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber
                    }
                );
            }

            return RedirectToAction("create");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/users/update-profile")]
        public IActionResult UpdateProfile(UpdateProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this._context.Users.FirstOrDefault(u => u.Id == model.UserId);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                this._context.Users.Update(user);
                this._context.SaveChanges();
            }

            return RedirectToAction("index");
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

        private string WelcomeEmailTemplate(string password, string recepientName, string role)
        {
            return EmailTemplateLayout(@"<tr>
                        <td><h3 style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:30px;'>Welcome to CSM Bataan Website!</h3></td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:0 30px 20px;text-align:center;'>
                                You have been invited as " + (role.ToLower() == "admin" ? "an <strong>" + role : "a <strong>" + role) + @"</strong>.<br />.
                            </p>                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style='font-family:Segoe, Segoe UI, Arial, sans-serif; margin:20px 30px 0; text-align:center;'>
                                <strong>Please use this one-time password to login :</strong>
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

        #region SMS
        //private void SMSSendNow(string message, string messageTo)
        //{
            //    var client = new RestClient(smsEndpoint);

            //    var request = new RestRequest("", Method.POST);
            //    request.AddParameter("apikey", smsApiKey);
            //    request.AddParameter("number", messageTo);
            //    request.AddParameter("message", message);
            //    request.AddParameter("sendername", "CSM Bataan Apps");

            //    IRestResponse response = client.Execute(request);
            //    var content = response.Content;


            //    //using (WebClient client = new WebClient())
            //    //{
            //    //    byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
            //    //        { "phone", "5557727420" },
            //    //        { "message", "Hello world" },
            //    //        { "key", "textbelt" },
            //    //      });

            //    //    string result = System.Text.Encoding.UTF8.GetString(response);
            //    //}
            //}
            #endregion
        #endregion
    }
}
