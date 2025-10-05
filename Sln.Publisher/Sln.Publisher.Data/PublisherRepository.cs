using System.Linq.Expressions;
using Sln.Publisher.Data.Abstractions;
using Sln.Shared.Data;
using Sln.Shared.Data.Services;

namespace Sln.Publisher.Data;

public class PublisherRepository<TEntity>
    (
        PublisherDbContext context
    )
    : RepositoryBase<TEntity, long>(0), IPublisherRepository<TEntity>
    where TEntity : class
{
     public override IQueryable<TEntity> GetAll()
        {
            var data = context.Set<TEntity>().AsQueryable();

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
            var entity = context.Set<TEntity>().FirstOrDefault(predicate);

            return entity;
        }

        public override IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var data = context.Set<TEntity>().Where(predicate);

            return data;
        }

        public override IQueryable<TEntity> Search(string? searchTerm)
        {
            var data = GetAll();

            return data;
        }

        public override TEntity Add(TEntity entity)
        {
            SetCreateAuditProperties(entity);
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public override List<TEntity> AddRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetCreateAuditProperties(entity);
            });
            context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public override TEntity Update(TEntity entity)
        {
            SetUpdateAuditProperties(entity);
            context.Set<TEntity>().Update(entity);
            return entity;
        }

        public override  List<TEntity> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetUpdateAuditProperties(entity);
            });
            context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public override TEntity Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);

            return entity;
        }

        public override List<TEntity> RemoveRange(List<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            return entities;
        }

        public override List<TEntity> DeleteRange(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                SetDeleteAuditProperties(entity);
            });
            context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public override TEntity Delete(TEntity entity)
        {
            SetDeleteAuditProperties(entity);
            context.Set<TEntity>().Update(entity);
            return entity;
        }
}