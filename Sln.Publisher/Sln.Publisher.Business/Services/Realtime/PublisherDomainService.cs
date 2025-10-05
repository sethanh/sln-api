using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sln.Shared.Business;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Data.Interfaces;

namespace Sln.Publisher.Business
{
    public class PublisherDomainService<TEntity>(IRepository<TEntity> repository)
        : DomainServiceBase<TEntity>(repository) where TEntity : class
    {
        public string GetCacheKey(string key)
        {
            return $"{typeof(TEntity).Name}_{key}";
        }
    }
}