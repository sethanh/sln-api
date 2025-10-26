using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Abstractions;
public interface IRelationRepository {}
public interface IMongoRepository {}
public interface IRepository<TEntity, in TKey> : IRepository where TEntity : class
{  
        IQueryable<TEntity> Search(string? searchTerm);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);

        // Query
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FindAsync(TKey id);

        // Command
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void UpdateRange(List<TEntity> entities);
        void AddRange(List<TEntity> entities);
        void RemoveRange(List<TEntity> entities);
        TEntity Remove(TKey id);
}

public interface IRelationDbRepository<TEntity, in TKey> : IRelationRepository, IRepository<TEntity, TKey> where TEntity : class
{
    
}

public interface IMongoDbRepository<TEntity, in TKey> : IMongoRepository, IRepository<TEntity, TKey> where TEntity : class
{
}
