using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface ICache
    {
        Task<T?> GetAsync<T>(string key) where T : class;
        Task RemoveAsync(string key);
        Task AddAsync(string key, object? data, DateTimeOffset expire);
    }
}