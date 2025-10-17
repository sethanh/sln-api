using System.Linq.Expressions;
using Sln.Publisher.Data.Abstractions;
using Sln.Shared.Data;
using Sln.Shared.Data.Services;

namespace Sln.Publisher.Data;

public class PublisherRepository<TEntity>(PublisherDbContext context)
    : RepositoryBase<TEntity, long>(context, null), IPublisherRepository<TEntity> where TEntity : class
{

}