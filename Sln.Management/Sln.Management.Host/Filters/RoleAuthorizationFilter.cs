using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Sln.Shared.Common.Enums.Accounts;

namespace Sln.Management.Host.Filters
{
    public class RoleAuthorizationFilter(string role) : IAuthorizationFilter
    {
        private readonly string _role = role;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            bool authorized = user != null && user.Identity != null && user.Identity.IsAuthenticated;
            if (!authorized)
            {
                context.Result = new UnauthorizedResult();
            }

            var roleClaimValue = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var isAllow = roleClaimValue == _role;

            if (roleClaimValue.IsNullOrEmpty() || !isAllow)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}