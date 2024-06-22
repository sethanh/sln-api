using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sln.Shared.Business;
using Sln.Shared.Business.Abstractions;
using Sln.Shared.Data.Abstractions;

namespace Sln.Management.Business
{
    public class ManagementDomainService<TEntity>(IRepository<TEntity> repository) 
        : DomainServiceBase<TEntity>(repository) where TEntity : class
    {
    }
}