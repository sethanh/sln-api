using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Search(string? searchTerm);
        TEntity Add(TEntity entity);
        List<TEntity> AddRange(List<TEntity> entities);
        TEntity Update(TEntity entity);
        List<TEntity> UpdateRange(List<TEntity> entities);
        TEntity Remove(TEntity entity);
        List<TEntity> RemoveRange(List<TEntity> entities);
        TEntity Delete(TEntity entity);
        List<TEntity> DeleteRange(List<TEntity> entities);
    }
}