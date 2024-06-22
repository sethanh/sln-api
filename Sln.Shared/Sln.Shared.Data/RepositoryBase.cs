using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data
{
    public abstract class RepositoryBase<TEntity>(long? accountId) : IRepository<TEntity> where TEntity : class
    {
        public long? AccountId { get; } = accountId;
        public void SetCreateAuditProperties(TEntity entity)
        {
            if (entity is not ICreationAuditModel createAuditProperties)
            {
                return;
            }

            createAuditProperties.CreationTime = DateTime.Now;
            createAuditProperties.CreatedId = AccountId;

            if (entity is not IDeletionAuditModel deleteAuditProperties)
            {
                return;
            }

            deleteAuditProperties.IsDeleted = false;
        }

        public void SetUpdateAuditProperties(TEntity entity)
        {
            if (entity is not IModificationAuditModel updateAuditProperties)
            {
                return;
            }

            updateAuditProperties.LastModificationId = AccountId;
            updateAuditProperties.LastModificationTime = DateTime.Now;
        }

        public bool SetDeleteAuditProperties(TEntity entity)
        {
            if (entity is not IDeletionAuditModel deleteAuditProperties)
            {
                return false;
            }

            deleteAuditProperties.DeletionTime = DateTime.Now;
            deleteAuditProperties.IsDeleted = true;

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