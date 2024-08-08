using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data
{
    public abstract class RepositoryBase<TEntity,TID>(TID? accountId) : IRepository<TEntity> 
        where TEntity : class
        where TID : struct
    {
        public TID? AccountId { get; } = accountId;
        public void SetCreateAuditProperties(TEntity entity)
        {
            if (entity is not ICreationAuditModel<TID> createAuditProperties)
            {
                return;
            }

            createAuditProperties.CreationTime = DateTime.Now;
            createAuditProperties.CreatedId = AccountId;

            if (entity is not IDeletionAuditModel<TID> deleteAuditProperties)
            {
                return;
            }

            deleteAuditProperties.IsDeleted = false;
        }

        public void SetUpdateAuditProperties(TEntity entity)
        {
            if (entity is not IModificationAuditModel<TID> updateAuditProperties)
            {
                return;
            }

            updateAuditProperties.LastModificationId = AccountId;
            updateAuditProperties.LastModificationTime = DateTime.Now;
        }

        public bool SetDeleteAuditProperties(TEntity entity)
        {
            if (entity is not IDeletionAuditModel<TID> deleteAuditProperties)
            {
                return false;
            }

            deleteAuditProperties.DeletionTime = DateTime.Now;
            deleteAuditProperties.IsDeleted = true;
            deleteAuditProperties.DeletedId = AccountId;

            return true;
        }

        public abstract IQueryable<TEntity> GetAll();
        public abstract IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter);
        public abstract TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        public abstract IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        public abstract IQueryable<TEntity> Search(string? searchTerm);
        public abstract TEntity Add(TEntity entity);
        public abstract List<TEntity> AddRange(List<TEntity> entities);
        public abstract TEntity Update(TEntity entity);
        public abstract List<TEntity> UpdateRange(List<TEntity> entities);
        public abstract TEntity Remove(TEntity entity);
        public abstract List<TEntity> RemoveRange(List<TEntity> entities);
        public abstract TEntity Delete(TEntity entity);
        public abstract List<TEntity> DeleteRange(List<TEntity> entities);
    }

}