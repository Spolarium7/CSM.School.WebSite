using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Security
{
    public static class WebUser
    {
        static IServiceProvider services = null;

        public static bool IsAuthenticated
        {
            get => Current.User.Identity.IsAuthenticated && UserId.HasValue;
        }

        public static void SetUser(User user)
        {
            EmailAddress = user.EmailAddress;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserId = user.Id;
        }

        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        public static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        public static string SessionCode
        {
            get => Current.Session.GetString("SessionCode");
            set => Current.Session.SetString("SessionCode", value);
        }

        public static Guid? UserId
        {
            get => Current.Session.GetObjectFromJson<Guid?>("UserId");
            set => Current.Session.SetObjectAsJson("UserId", value);
        }

        public static string FirstName
        {
            get => Current.Session.GetString("FirstName");
            set => Current.Session.SetString("FirstName", value);
        }

        public static string LastName
        {
            get => Current.Session.GetString("LastName");
            set => Current.Session.SetString("LastName", value);
        }

        public static string EmailAddress
        {
            get => Current.Session.GetString("EmailAddress");
            set => Current.Session.SetString("EmailAddress", value);
        }

        public static string FullName
        {
            get => string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
