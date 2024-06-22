using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Sln.Shared.Common.Enums.Accounts;
using Sln.Shared.Common.Exceptions;

namespace Sln.Shared.Host.Attributes
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            bool authorized = user != null && user.Identity != null && user.Identity.IsAuthenticated;
            if (!authorized)
            {
                throw new HttpUnauthorized("User is not authenticated.");
            }

            var roleClaimValue = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var isAdmin = roleClaimValue == AccountRoleClaims.Management.ToString() || roleClaimValue == AccountRoleClaims.Admin.ToString();
            if (roleClaimValue.IsNullOrEmpty() || !isAdmin)
            {
                throw new HttpForbidden("User does not have Admin role.");
            }
        }
    }
}