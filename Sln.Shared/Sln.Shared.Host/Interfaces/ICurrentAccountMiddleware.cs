using Microsoft.AspNetCore.Http;
using Sln.Shared.Common.Interfaces;

namespace Sln.Shared.Host.Interfaces
{
    public interface ICurrentAccountMiddleware {

    }

    public interface ICurrentAccountMiddleware<T> : ICurrentAccountMiddleware where T : ICurrentAccount
    {
        Task InvokeAsync(HttpContext context, T currentAccount);
    }
}