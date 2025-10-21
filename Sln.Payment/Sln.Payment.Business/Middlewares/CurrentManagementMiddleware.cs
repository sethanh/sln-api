using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Sln.Payment.Common.Models;
using Sln.Shared.Host.Middlewares;

namespace Sln.Payment.Business.Middlewares
{
     public class CurrentAccountMiddleware(RequestDelegate next) 
        : CurrentAccountMiddlewareBase<CurrentPaymentAccount>(next)
    {
        private readonly RequestDelegate _next = next;
        
        public override async Task InvokeAsync(HttpContext context, CurrentPaymentAccount currentAccount)
        {
            var user = context.User;
            bool authorized = user != null && user.Identity != null && user.Identity.IsAuthenticated;

            if (authorized)
            {
                var claimsPrincipal = context.User;

                // Extract the claims
                var identifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var email = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
                var name = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
                var role = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;

                Guid accountId = Guid.Empty;
                if (!string.IsNullOrEmpty(identifier) && Guid.TryParse(identifier, out var parsedIdentifier))
                {
                    accountId = parsedIdentifier;
                }

                var organizationIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
                Guid organizationId = Guid.Empty;
                if (!string.IsNullOrEmpty(organizationIdClaim) && Guid.TryParse(organizationIdClaim, out var parsedOrganizationId))
                {
                    organizationId = parsedOrganizationId;
                }

                currentAccount.OrganizationId = organizationId;
                currentAccount.Id = accountId;
                currentAccount.Email = email;
                currentAccount.Name = name;
                currentAccount.Role = role;
            }

            await _next(context);
        }
    }
}