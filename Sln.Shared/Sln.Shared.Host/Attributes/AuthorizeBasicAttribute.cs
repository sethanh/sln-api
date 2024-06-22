using Microsoft.AspNetCore.Authorization;

namespace Sln.Shared.Host.Attributes
{
    public class AuthorizeBasicAttribute : AuthorizeAttribute
    {
        public AuthorizeBasicAttribute()
        {
            AuthenticationSchemes = "InternalAuthentication";
        }
    }
}