using Sln.Shared.Data.Abstractions;

namespace Sln.Scheduler.Data.Abstractions;

public interface ISchedulerRepository<TEntity> : IRelationDbRepository<TEntity, long> where TEntity : class
{
    
}