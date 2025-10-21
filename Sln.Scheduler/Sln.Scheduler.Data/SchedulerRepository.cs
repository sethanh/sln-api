using Sln.Scheduler.Data.Abstractions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Sln.Scheduler.Data;

public class SchedulerRepository<TEntity>(SchedulerDbContext context) : ISchedulerRepository<TEntity> where TEntity : class
{
    private readonly SchedulerDbContext _context = context;

    public IQueryable<TEntity> GetAll()
    {
        var data = _context.Set<TEntity>();
        return data;
    }


    public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
        var data = _context.Set<TEntity>().Where(predicate);
        return data;
    }

    public async Task<TEntity?> FindAsync(Guid? id)
    {
        if (id == default)
        {
            return null;
        }

        var entity = await _context.Set<TEntity>().FindAsync(id);

        return entity;
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void UpdateRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
    }

    public void AddRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public void RemoveRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public Task<TEntity> Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return Task.FromResult(entity);
    }

    public TEntity Remove(Guid id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
        {
            throw new Exception($"Entity with id {id} not found");
        }
        _context.Set<TEntity>().Remove(entity);
        return entity;
    }

    public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter)
    {
        return source;
    }

    public IQueryable<TEntity> Search(string? searchTerm)
    {
        var data = _context.Set<TEntity>();
        return data;
    }

    public void RemoveHardRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public Task<TEntity?> FindAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
