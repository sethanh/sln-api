using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Sln.Shared.Host.Middlewares;

namespace Sln.Shared.Host.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCurrentAccount(this IApplicationBuilder app)
        {
            app.UseMiddleware<CurrentAccountMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            return app;
        }
    }
}