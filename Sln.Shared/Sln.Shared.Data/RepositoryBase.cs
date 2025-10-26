using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Extensions;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Data.Attributes;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data
{
    public abstract class RepositoryBase<TEntity, TID>(
        DbContext _context,
        TID? accountId
    ) : IRepository<TEntity, TID> 
        where TEntity : class
        where TID : struct
    {
        public TID? AccountId { get; } = accountId;

        #region --- Audit Helpers ---
        public void SetCreateAuditProperties(TEntity entity)
        {
            if (entity is not ICreationAuditModel<TID> createAuditProperties)
                return;

            createAuditProperties.CreationTime = DateTime.Now;
            createAuditProperties.CreatedId = AccountId;

            if (entity is not IDeletionAuditModel<TID> deleteAuditProperties)
                return;

            deleteAuditProperties.IsDeleted = false;
        }

        public void SetUpdateAuditProperties(TEntity entity)
        {
            if (entity is not IModificationAuditModel<TID> updateAuditProperties)
                return;

            updateAuditProperties.LastModificationId = AccountId;
            updateAuditProperties.LastModificationTime = DateTime.Now;
        }

        public void SetDeleteAuditProperties(TEntity entity)
        {
            if (entity is not IDeletionAuditModel<TID> deleteAuditProperties)
                return;

            deleteAuditProperties.DeletionTime = DateTime.Now;
            deleteAuditProperties.IsDeleted = true;
            deleteAuditProperties.DeletedId = AccountId;
        }
        #endregion

        #region --- Query ---
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter)
        {
            if (string.IsNullOrEmpty(astFilter))
                return source;

            // TODO: Apply actual filter expression if needed
            return source;
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> Search(string? searchTerm)
        {
            var data = GetAll();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return data;

            return data.QuerySearchable<TEntity, SearchableAttribute>(searchTerm);
        }

        public async Task<TEntity?> FindAsync(TID id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        #endregion

        #region --- Create ---
        public TEntity Add(TEntity entity)
        {
            SetCreateAuditProperties(entity);
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            SetCreateAuditProperties(entity);
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            entities.ForEach(SetCreateAuditProperties);
            _context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(SetCreateAuditProperties);
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region --- Update ---
        public TEntity Update(TEntity entity)
        {
            SetUpdateAuditProperties(entity);
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        async Task<TEntity> IRepository<TEntity, TID>.Update(TEntity entity)
        {
            SetUpdateAuditProperties(entity);
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(SetUpdateAuditProperties);
            _context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        void IRepository<TEntity, TID>.UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(SetUpdateAuditProperties);
            _context.Set<TEntity>().UpdateRange(entities);
            _context.SaveChanges();
        }
        #endregion

        #region --- Delete ---
        public TEntity Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public TEntity Remove(TID id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
                throw new InvalidOperationException($"Entity {typeof(TEntity).Name} with id {id} not found.");

            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public List<TEntity> RemoveRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return entities;
        }

        void IRepository<TEntity, TID>.RemoveRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public TEntity Delete(TEntity entity)
        {
            SetDeleteAuditProperties(entity);
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public List<TEntity> DeleteRange(List<TEntity> entities)
        {
            entities.ForEach(SetDeleteAuditProperties);
            _context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        void IRepository<TEntity, TID>.AddRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
