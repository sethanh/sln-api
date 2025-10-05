using Sln.Shared.Common.Abstractions;
using Sln.Shared.Data.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Services;

public class ModelCacheService: IScopedService
{
    private readonly ICacheService? _cache;
    public ModelCacheService(IServiceProvider serviceProvider)
    {
        try
        {
            _cache = serviceProvider.GetRequiredService<IRedisCacheService>();   
        }
        catch (Exception e)
        {
            // ignored
        }
    }
    
    #region Cache utils
    // Generate cache key for specific Entity Type {EntityType}_key
    public string GetCacheKey<TEntity>(string key)
    {
        return $"{typeof(TEntity).Name}_{key}";
    }
    
    public string GetCacheKey<TEntity>(TEntity? entity)
    {
        if (entity == null) return string.Empty;
        if (entity is IDataModel e)
        {
            var idProp = typeof(TEntity).GetProperty("Id")?.Name;
            if (string.IsNullOrEmpty(idProp)) return string.Empty;
            var value = typeof(TEntity).GetProperty(idProp)?.GetValue(entity);
            return GetCacheKey<TEntity>(value?.ToString() ?? "");
        }
        return string.Empty;
    }
    
    public string GetCacheKey<TEntity>(object? key)
    {
        if (key != null)
        {
            return GetCacheKey<TEntity>(key.ToString() ?? "");
        }
        return string.Empty;
    }
    
    // Set cache for Entity Type
    public void SetCache<TEntity>(TEntity? entity, int cacheTimeInMinute = 15)
    {
        // todo: Implement cache for better way
        // cache is not register
        // if (_cache == null) return;
        // var key = GetCacheKey<TEntity>(entity);
        // RemoveCache(key);
        // if (entity == null) return;
        // _cache.Add(key, entity, DateTimeOffset.Now.AddMinutes(cacheTimeInMinute));
    }
    
    // Get cache for Entity Type
    public TEntity? GetCache<TEntity, TKey>(TKey? id)
    {
        var cacheKey = GetCacheKey<TEntity>(id);
        return GetCache<TEntity>(cacheKey);
    }

    public TEntity? GetCache<TEntity>(string? key)
    {
        return default;
        // todo: Implement better way
        // cache is not config
        // if (_cache == null || string.IsNullOrEmpty(key)) return default;
        // return _cache.Get<TEntity>(key);
    }
    
    // Remove cache for Entity Type
    public void RemoveCache(string key)
    {
        // todo: implement better way
        // cache is not config
        // if (_cache == null) return;
        // _cache.Remove(key);
    }

    public void RemoveCache<TEntity>(object? id)
    {
        var cacheKey = GetCacheKey<TEntity>(id);
        RemoveCache(cacheKey);
    }

    public void RemoveCache<TEntity>(TEntity? entity)
    {
        var cacheKey = GetCacheKey<TEntity>(entity);
        RemoveCache(cacheKey);
    }

    #endregion
}