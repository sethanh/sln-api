using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Sln.Shared.Common.Services;

namespace Sln.Shared.Host.Middlewares
{
    public class CurrentAccountMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context, CurrentAccount currentAccount)
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

                long accountId = 0;
                if (!string.IsNullOrEmpty(identifier) && long.TryParse(identifier, out var parsedIdentifier))
                {
                    accountId = parsedIdentifier;
                }

                var SlnanizationIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "SlnanizationId")?.Value;
                long SlnanizationId = 0;
                if (!string.IsNullOrEmpty(SlnanizationIdClaim) && long.TryParse(SlnanizationIdClaim, out var parsedSlnanizationId))
                {
                    SlnanizationId = parsedSlnanizationId;
                }

                currentAccount.SlnanizationId = SlnanizationId;
                currentAccount.Id = accountId;
                currentAccount.Email = email;
                currentAccount.Name = name;
                currentAccount.Role = role;
            }

            await _next(context);
        }

    }
}