using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Sln.Shared.Data;

namespace Sln.Management.Data
{
    public class ManagementRedisCache(IDistributedCache cache) : CacheBase
    {
        private readonly IDistributedCache _cache = cache;

        public override async Task AddAsync(string key, object? data, DateTimeOffset expire)
        {
            try
            {
                if (data == null) return;

                string cachedDataString = JsonSerializer.Serialize(data);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                DistributedCacheEntryOptions? options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expire.DateTime.Subtract(DateTime.Now));
                await _cache.SetAsync(key: key, dataToCache, options);
            }
            catch
            {
                //do not thing
            }
        }

        public override async Task<T?> GetAsync<T>(string key) where T : class
        {
            try
            {
                byte[]? cachedData = await _cache.GetAsync(key);
                if (cachedData != null)
                {
                    // If the data is found in the cache, encode and deserialize cached data.
                    var cachedDataString = Encoding.UTF8.GetString(cachedData);
                    var data = JsonSerializer.Deserialize<T>(cachedDataString);
                    return data;
                }
            }
            catch
            {

            }

            return null;
        }

        public override async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}