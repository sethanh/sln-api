using Sln.Shared.Data.Abstractions;

namespace Sln.Publisher.Data.Abstractions;

public interface IPublisherRepository<TEntity> : IMongoDbRepository<TEntity,Guid> where TEntity: class
{
    
}