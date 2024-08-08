using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data
{
    public abstract class CacheBase : ICache
    {
        public abstract Task<T?> GetAsync<T>(string key) where T : class;
        public abstract Task RemoveAsync(string key);
        public abstract Task AddAsync(string key, object? data, DateTimeOffset expire);
    }
}