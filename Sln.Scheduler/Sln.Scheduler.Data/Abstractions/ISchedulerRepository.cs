using Sln.Shared.Data.Abstractions;

namespace Sln.Scheduler.Data.Abstractions;

public interface ISchedulerRepository<TEntity> : IRelationDbRepository<TEntity, Guid> where TEntity : class
{

}