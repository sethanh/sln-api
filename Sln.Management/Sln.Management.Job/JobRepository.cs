using Sln.Shared.Data;
using Sln.Management.Data;
using System.Linq.Expressions;
using Sln.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Sln.Management.Job;

public class JobRepository<TEntity>(ManagementDbContext context)
    : RepositoryBase<TEntity, long>(context, null), IJobRepository<TEntity>
    where TEntity : class
{
    private readonly DbContextBase _context = context;

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

    Task<TEntity> IRepository<TEntity, long>.Update(TEntity entity)
    {
        SetUpdateAuditProperties(entity);
        _context.Set<TEntity>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await  _context.Set<TEntity>().AddRangeAsync(entities);
    }

    void IRepository<TEntity, long>.UpdateRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
    }

    void IRepository<TEntity, long>.AddRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    void IRepository<TEntity, long>.RemoveRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public async Task<TEntity?> FindAsync(long id)
    {
        var data = await _context.Set<TEntity>().FindAsync(id);

        return data;
    }

    public TEntity Remove(long id)
    {
        var entity = _context.Set<TEntity>().Find(id);

        if (entity is null)
        {
            throw new Exception("ENTITY_NOT_FOUND");
        }
        _context.Set<TEntity>().Remove(entity);
        return entity;
    }
}
