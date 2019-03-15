using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Security
{
    public class AuthorizeContentAdminRequirementHandler : AuthorizationHandler<AuthorizeContentAdminRequirement>
    {
        public AuthorizeContentAdminRequirementHandler() { }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeContentAdminRequirement requirement)
        {
            if (!WebUser.IsInRole(Data.Enums.Role.ContentAdmin) && !WebUser.IsInRole(Data.Enums.Role.Admin))
            {
                context.Fail();

                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

    public class AuthorizeContentAdminRequirement : IAuthorizationRequirement
    {
    }
}
