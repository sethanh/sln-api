using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sln.Shared.Business.Interfaces
{
    public interface IDomainService
    { }
    public interface IDomainService<TEntity> : IDomainService where TEntity : class
    {
        IQueryable<TEntity> Search(string? searchTerm);


        IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(string? search, string? filter);
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);


        List<TEntity> UpdateRange(List<TEntity> entities);

        List<TEntity> DeleteRange(List<TEntity> entities);

        List<TEntity> RemoveRange(List<TEntity> entities);
    }
}