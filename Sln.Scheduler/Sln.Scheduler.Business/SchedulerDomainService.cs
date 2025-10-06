using System.Linq.Expressions;
using Sln.Scheduler.Data.Abstractions;
using Sln.Shared.Business;
using Sln.Shared.Data.Interfaces;


namespace Sln.Scheduler.Business;

public class SchedulerDomainService<TEntity>(IRepository<TEntity> mainRepository)
    : DomainServiceBase<TEntity>(mainRepository) where TEntity : class;
