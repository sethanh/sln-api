using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sln.Shared.Common.Exceptions;

namespace Sln.Shared.Host.Middlewares
{
    public class GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var details = exception.Message;

            if (exception is HttpException httpException)
            {
                int statusCode = (int)httpException.StatusCode;
                context.Response.StatusCode = statusCode;

                var httpResponse = new
                {
                    code = statusCode,
                    message = httpException.StatusCode.ToString(),
                    details
                };

                return context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }

            return Task.CompletedTask;
        }
    }
}