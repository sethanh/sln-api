using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Sln.Management.Data;

namespace Sln.Management.Host.Filters
{
    public class CacheResourceFilter(IMemoryCache cache) : IResourceFilter
    {
        private readonly IMemoryCache _cache = cache;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Kiểm tra cache
            if (_cache.TryGetValue(context.HttpContext.Request.Path, out var cachedResult))
            {
                // Nếu có trong cache, trả về dữ liệu từ cache và không tiếp tục xử lý action
                context.Result = (IActionResult)cachedResult;
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Lưu kết quả vào cache nếu nó không có trong cache
            if (context.Result != null && !_cache.TryGetValue(context.HttpContext.Request.Path, out _))
            {
                _cache.Set(context.HttpContext.Request.Path, context.Result);
            }
        }
    }
}