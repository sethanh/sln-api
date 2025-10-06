using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data.Abstractions;
using MongoDB.Driver.Linq;
using Sln.Shared.Data.Models;
using Sln.Shared.Common.Helpers;
using Sln.Shared.Data.Interfaces;

namespace Sln.Management.Job;

public abstract class JobUnitOfWork<TContext>(
    TContext context
    ) : IJobUnitOfWork where TContext : DbContext
{
    private readonly TContext _context = context;

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public virtual void Dispose()
    {
        _context.Database.CurrentTransaction?.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public void ResetTracker()
    {
        context.ChangeTracker.Clear();
    }


    public async Task SaveChangesAsync()
    {
        var states = new[] { EntityState.Added, EntityState.Deleted, EntityState.Modified };
        var changeEntities = _context.ChangeTracker
            .Entries().Where(e => states.Contains(e.State))
            .ToList();

        var changeIModelEntities = changeEntities.Where(e => e.Entity is IDataModel)
            .Select(e => new ChangeIModelEntity
            {
                State = e.State,
                Entity = e.Entity,
                DataChanges = EntityHelper.GetDataChanges(e)
            })
            .ToList();

        await _context.SaveChangesAsync();
    }
}
