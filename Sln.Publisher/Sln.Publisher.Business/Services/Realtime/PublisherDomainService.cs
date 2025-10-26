using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sln.Publisher.Data.Abstractions;
using Sln.Shared.Business;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Host.Base;

namespace Sln.Publisher.Business
{
    public class PublisherDomainService<TEntity>(IPublisherRepository<TEntity> repository) : BaseDomainService<TEntity, Guid>(repository) where TEntity : class
    {
    
    }
}