namespace Sln.Shared.Host.Interfaces;

public interface IDomainService
{

}

public interface IBaseDomainService<TEntity> : IDomainService where TEntity: class
{
    string GetCacheKey(string key);
}