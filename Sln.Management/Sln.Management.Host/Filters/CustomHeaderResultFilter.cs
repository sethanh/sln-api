using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sln.Management.Host.Filters
{
    public class CustomHeaderResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context?.HttpContext?.Response?.Headers?.Add("X-Custom-Header", "This is a custom header");
            Console.WriteLine("Custom header added to response.");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Thực hiện sau khi kết quả đã được gửi đi
            Console.WriteLine("Result has been sent to the client.");
        }
    }
}