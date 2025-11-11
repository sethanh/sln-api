using System.Linq.Expressions;
using Sln.Payment.Data.Abstractions;
using Sln.Shared.Business;
using Sln.Shared.Data.Interfaces;


namespace Sln.Payment.Business;

public class SchedulerDomainService<TEntity>(IRepository<TEntity> mainRepository)
    : DomainServiceBase<TEntity>(mainRepository) where TEntity : class;
