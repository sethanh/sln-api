using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Helpers;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Data.Models;
using Sln.Shared.Data.Requests;

namespace Sln.Shared.Data
{
    public abstract class UnitOfWorkBase<TContext>(
        TContext context,
        IPublisher publisher
    ) : IUnitOfWork where TContext : DbContext
    {

        public async Task BeginTransactionAsync()
        {
            await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await context.Database.CommitTransactionAsync();
        }

        public virtual void Dispose()
        {
            context.Database.CurrentTransaction?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task RollbackTransactionAsync()
        {
            await context.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            var states = new[] { EntityState.Added, EntityState.Deleted, EntityState.Modified };
            var changeEntities = context.ChangeTracker
                .Entries().Where(e => states.Contains(e.State))
                .ToList();
            var changeIModelEntities = changeEntities.Where(e => e.Entity is IDataModel)
            .Select(e => new ChangeIModelEntity
            {
                State = e.State,
                Entity = e.CurrentValues.ToObject(),
                DataChanges = EntityHelper.GetDataChanges(e)
            })
            .ToList();

            await context.SaveChangesAsync();

            await AfterSaveChangeAsync(
                changeIModelEntities
            );
        }

         private async Task AfterSaveChangeAsync(
        List<ChangeIModelEntity> changeIModelEntities
        )
    {
        try
        {
            foreach (var entity in changeIModelEntities)
            {
                var DeleterId = entity.DataChanges?.FirstOrDefault(e => e.Field == "DeleterId")?.ChangedValue;

                if(entity.State == EntityState.Added)
                {
                    await publisher.Publish(new ModelCreateEventRequest<IDataModel>() { 
                        Data = (IDataModel)entity.Entity, 
                        DataChanges = entity.DataChanges
                    });
                }
                else if(entity.State == EntityState.Deleted || DeleterId != null)
                {
                    await publisher.Publish(new ModelDeleteEventRequest<IDataModel>() { 
                        Data = (IDataModel)entity.Entity,
                        DataChanges = entity.DataChanges
                    });
                }
                else if(entity.State == EntityState.Modified && DeleterId == null)
                {
                    await publisher.Publish(new ModelModifyEventRequest<IDataModel>() { 
                        Data = (IDataModel)entity.Entity,
                        DataChanges = entity.DataChanges
                    });
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    }
}