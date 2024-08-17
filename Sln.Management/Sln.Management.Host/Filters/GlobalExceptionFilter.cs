using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sln.Management.Host.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log ngoại lệ
            var exception = context.Exception;
            Console.WriteLine($"Exception caught: {exception.Message}");

            // Thiết lập kết quả trả về tùy chỉnh
            context.Result = new ContentResult
            {
                Content = "An unexpected error occurred. Please try again later.",
                StatusCode = 500
            };

            // Đánh dấu ngoại lệ đã được xử lý
            context.ExceptionHandled = true;
        }
    }
}