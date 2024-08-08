using Microsoft.AspNetCore.Http;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Host.Interfaces;

namespace Sln.Shared.Host.Middlewares
{
    public abstract class CurrentAccountMiddlewareBase<T>(RequestDelegate next)
        : ICurrentAccountMiddleware<T>  where T : ICurrentAccount
    {
        private readonly RequestDelegate _next = next;

        public abstract Task InvokeAsync(HttpContext context, T currentAccount);
    }
}