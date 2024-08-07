using Microsoft.AspNetCore.Http;
using Sln.Shared.Common.Services;

namespace Sln.Shared.Host.Abstractions
{
    public interface ICurrentAccountMiddleware {

    }

    public interface ICurrentAccountMiddleware<T> : ICurrentAccountMiddleware where T : ICurrentAccount
    {
        Task InvokeAsync(HttpContext context, T currentAccount);
    }
}