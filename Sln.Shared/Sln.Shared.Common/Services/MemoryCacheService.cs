using Sln.Shared.Common.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Sln.Shared.Common.Interfaces;

namespace Sln.Shared.Common.Services;

public class MemoryCacheService(IMemoryCache memCache) : IMemoryCacheService
{
    public T? Get<T>(string key)
    {
        if (string.IsNullOrEmpty(key)) return default;
        return memCache.Get<T>(key);
    }

    public void Remove(string key)
    {
        if (string.IsNullOrEmpty(key)) return;
        memCache.Remove(key);
    }

    public void Add<T>(string key, T? data, DateTimeOffset expire)
    {
        if (string.IsNullOrEmpty(key)) return;
        memCache.Set(key, data);
    }
}