using Sln.Shared.Data;
using Sln.Management.Data;
using System.Linq.Expressions;
using Sln.Shared.Data.Abstractions;
using Sln.Management.Data.Attributes;
using Sln.Shared.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Sln.Management.Job;

public class JobRepository<TEntity>(ManagementDbContext context)
    : RepositoryBase<TEntity, long>(0), IJobRepository<TEntity>
    where TEntity : class
{
    private readonly DbContextBase _context = context;

    public override IQueryable<TEntity> GetAll()
    {
        var data = _context.Set<TEntity>().AsQueryable();

        return data;
    }

    public override IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter)
    {
        if (string.IsNullOrEmpty(astFilter))
        {
            return source;
        }

        return source;
    }

    public override TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(predicate);

        return entity;
    }

    public override IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
        var data = _context.Set<TEntity>().Where(predicate);

        return data;
    }

    public override IQueryable<TEntity> Search(string? searchTerm)
    {
        var data = GetAll();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return data;
        }
        return data.QuerySearchable<TEntity, SearchableAttribute>(searchTerm);
    }

    public override TEntity Add(TEntity entity)
    {
        SetCreateAuditProperties(entity);
        _context.Set<TEntity>().Add(entity);
        return entity;
    }

    public override List<TEntity> AddRange(List<TEntity> entities)
    {
        entities.ForEach(entity =>
        {
            SetCreateAuditProperties(entity);
        });
        _context.Set<TEntity>().AddRange(entities);
        return entities;
    }

    public override TEntity Update(TEntity entity)
    {
        SetUpdateAuditProperties(entity);
        _context.Set<TEntity>().Update(entity);
        return entity;
    }

    public override List<TEntity> UpdateRange(List<TEntity> entities)
    {
        entities.ForEach(entity =>
        {
            SetUpdateAuditProperties(entity);
        });
        _context.Set<TEntity>().UpdateRange(entities);
        return entities;
    }

    public override TEntity Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

        return entity;
    }

    public override List<TEntity> RemoveRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        return entities;
    }

    public override List<TEntity> DeleteRange(List<TEntity> entities)
    {
        entities.ForEach(entity =>
        {
            SetDeleteAuditProperties(entity);
        });
        _context.Set<TEntity>().UpdateRange(entities);
        return entities;
    }

    public override TEntity Delete(TEntity entity)
    {
        SetDeleteAuditProperties(entity);
        _context.Set<TEntity>().Update(entity);
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
