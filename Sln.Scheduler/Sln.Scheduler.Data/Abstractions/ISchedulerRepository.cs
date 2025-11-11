using Sln.Shared.Data.Abstractions;

namespace Sln.Payment.Data.Abstractions;

public interface ISchedulerRepository<TEntity> : IRelationDbRepository<TEntity, Guid> where TEntity : class
{

}