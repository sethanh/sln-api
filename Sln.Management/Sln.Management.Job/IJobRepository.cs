using Sln.Shared.Common.Abstractions;
using Sln.Shared.Data.Abstractions;

namespace Sln.Management.Job;

public interface IJobRepository<TEntity> : IRelationDbRepository<TEntity, long> where TEntity : class
{
}
