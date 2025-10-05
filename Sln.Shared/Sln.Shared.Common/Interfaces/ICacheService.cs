namespace Sln.Shared.Common.Interfaces;

public interface ICacheService
{
    T? Get<T>(string key);
    void Remove(string key);
    void Add<T>(string key, T? data, DateTimeOffset expire);
}