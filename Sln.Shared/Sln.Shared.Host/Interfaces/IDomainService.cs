using Sln.Shared.Business.Interfaces;

namespace Sln.Shared.Host.Interfaces;

public interface IBaseDomainService<TEntity> : IDomainService where TEntity: class
{
    string GetCacheKey(string key);
}