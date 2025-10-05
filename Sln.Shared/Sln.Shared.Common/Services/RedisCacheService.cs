using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sln.Shared.Common.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Sln.Shared.Common.Interfaces;

namespace Sln.Shared.Common.Services;

public class RedisCacheService(IDistributedCache cache) : IRedisCacheService
{
    public void Add<T>(string key, T? data, DateTimeOffset expire)
    {
        if (string.IsNullOrEmpty(key)) return;
        if (data == null) return;
        try
        {

            string cachedDataString = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                MaxDepth = null
            });
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(expire.DateTime.Subtract(DateTime.Now));
            cache.Set(key: key, dataToCache, options);
        }
        catch(Exception e)
        {
            Console.Error.WriteLine(e.Message);
            //do not thing
        }
    }

    public T? Get<T>(string key)
    {
        try
        {
            if (string.IsNullOrEmpty(key)) return default;
            byte[]? cachedData = cache.Get(key);
            if (cachedData != null)
            {
                // If the data is found in the cache, encode and deserialize cached data.
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                var data = JsonConvert.DeserializeObject<T>(cachedDataString);
                return data;
            }
        }
        catch
        {
            //do not thing
        }

        return default;
    }

    public void Remove(string key)
    {
        if (string.IsNullOrEmpty(key)) return;
        cache.Remove(key);
    }
}