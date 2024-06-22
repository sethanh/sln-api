using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sln.Shared.Host.Configurations
{
    class InternalAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IConfiguration configuration) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        private readonly IConfiguration _configuration = configuration;

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var internalAuthUserName = _configuration["InternalAuthentication:Username"];
                var internalAuthPassword = _configuration["InternalAuthentication:Password"];

                var authorizationHeader = Request.Headers.Authorization;
                var authHeader = AuthenticationHeaderValue.Parse(authorizationHeader!);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter!);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split([':'], 2);
                var username = credentials[0];
                var password = credentials[1];

                if (username != internalAuthUserName || password != internalAuthPassword)
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
                }

                var authenticationTicket = new AuthenticationTicket(
                    new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new[] { new Claim(ClaimTypes.Name, username) },
                            Scheme.Name
                        )
                    ),
                    Scheme.Name
                );

                return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Error Occurred. Authorization failed."));
            }
        }
    }
}