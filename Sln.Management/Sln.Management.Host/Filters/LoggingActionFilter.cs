using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sln.Management.Host.Filters
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var parameters = context.ActionArguments;

            Console.WriteLine($"[{DateTime.UtcNow}]: Executing action {controllerName}/{actionName}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            Console.WriteLine($"[{DateTime.UtcNow}]: Executed action {controllerName}/{actionName}");
        }
    }
}