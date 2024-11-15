using System.Text.Json;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Sln.Payment.Data;
using Sln.Shared.Business;
using Sln.Shared.Common.Extensions;

namespace Sln.Payment.Business
{
    public class PaymentReportService(
        IServiceProvider serviceProvider
        ) : ReportServiceBase
    {
        private IServiceProvider ServiceProvider { get; } = serviceProvider;
        protected IMapper Mapper => ServiceProvider.GetRequiredService<IMapper>();
        protected PaymentRedisCache RedisCache => ServiceProvider.GetRequiredService<PaymentRedisCache>();
        protected PaymentDapperQuery DapperQuery => ServiceProvider.GetRequiredService<PaymentDapperQuery>();

        public override async Task<IEnumerable<T>> Query<T>(
            string sql,
            object? param = null,
            bool ignoreCache = false
            ) where T : class
        {
            if (ignoreCache)
            {
                return DapperQuery.Query<T>(sql, param);
            }
            var cacheKey = $"{sql}{JsonSerializer.Serialize(param ?? new { })}".GetMD5Hash();
            var result = await RedisCache.GetAsync<List<T>>(cacheKey);
            if (result != null) return result;
            var rs = DapperQuery.Query<T>(sql, param);
            await RedisCache.AddAsync(cacheKey, rs.ToList(), DateTimeOffset.Now.AddMinutes(5));
            return rs;
        }

        public override async Task<T?> QuerySingle<T>(
            string sql,
            object? param = null,
            bool ignoreCache = false
            ) where T : class
        {
            if (ignoreCache)
            {
                return DapperQuery.QuerySingle<T>(sql, param);
            }
            var cacheKey = $"{sql}{JsonSerializer.Serialize(param ?? new { })}".GetMD5Hash();
            var result = await RedisCache.GetAsync<T>(cacheKey);
            if (result != null) return result;
            var rs = DapperQuery.QuerySingle<T>(sql, param);
            await RedisCache.AddAsync(cacheKey, rs, DateTimeOffset.Now.AddMinutes(5));
            return rs;
        }
    }
}