using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Extensions;
using Sln.Shared.Data.Attributes;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data
{
    public abstract class RepositoryBase<TEntity,TID>(
        DbContext _context,
        TID? accountId
    ) : IRepository<TEntity> 
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

        public IQueryable<TEntity> GetAll()
        {
            var data = _context.Set<TEntity>().AsQueryable();

            return data;
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter)
        {
            if (string.IsNullOrEmpty(astFilter))
            {
                return source;
            }

            return source;
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);

            return entity;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _context.Set<TEntity>().Where(predicate);

            return data;
        }

        public IQueryable<TEntity> Search(string? searchTerm)
        {
            var data = GetAll();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return data;
            }
            return data.QuerySearchable<TEntity, SearchableAttribute>(searchTerm);
        }

        public TEntity Add(TEntity entity)
        {
            SetCreateAuditProperties(entity);
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetCreateAuditProperties(entity);
            });
            _context.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            SetUpdateAuditProperties(entity);
            _context.Set<TEntity>().Update(entity);
            return entity;
        }


        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetUpdateAuditProperties(entity);
            });
            _context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public TEntity Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            return entity;
        }
        
        public List<TEntity> RemoveRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return entities;
        }

        public List<TEntity> DeleteRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetDeleteAuditProperties(entity);
            });
            _context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public TEntity Delete(TEntity entity)
        {
            SetDeleteAuditProperties(entity);
            _context.Set<TEntity>().Update(entity);
            return entity;
        }
    }

}