using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Host.Abstractions;
using Sln.Shared.Host.Middlewares;

namespace Sln.Shared.Host.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseCurrentAccount(
            this IApplicationBuilder app
        )
        {
            var appName = Environment.GetEnvironmentVariable(EnvConstants.APP_NAME) ?? throw new Exception("App Name is not set.");
            
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(e => 
                    e.GetReferencedAssemblies().Select(s => s)
                )
                .Where(a => a.FullName?.StartsWith(appName) ?? false)
                .DistinctBy(e => e.FullName)
    .           Select(Assembly.Load);

            var types = assemblies.SelectMany(a => a.GetExportedTypes());

            var applicationBuilders = types
                .Where(t => t.IsAssignableTo(typeof(ICurrentAccountMiddleware)) && !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var applicationBuilder in applicationBuilders)
            {
                app.UseMiddleware(applicationBuilder);
            }

            return app;
        }
    }
}