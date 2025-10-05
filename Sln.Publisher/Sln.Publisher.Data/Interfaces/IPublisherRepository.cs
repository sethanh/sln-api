using Sln.Shared.Data.Abstractions;

namespace Sln.Publisher.Data.Abstractions;

public interface IPublisherRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity: class
{
    
}