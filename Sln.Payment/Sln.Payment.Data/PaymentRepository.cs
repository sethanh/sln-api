using Sln.Payment.Common.Models;
using Sln.Payment.Data.Attributes;
using Sln.Shared.Common.Extensions;
using Sln.Shared.Data;
using Sln.Shared.Data.Interfaces;
using System.Linq.Expressions;

namespace Sln.Payment.Data
{
    public class PaymentRepository<TEntity>(
        PaymentDbContext context,
        CurrentPaymentAccount currentAccount
        ) : RepositoryBase<TEntity, long>(currentAccount.Id), IRepository<TEntity> where TEntity : class
    {
        private readonly PaymentDbContext _context = context;

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

        public override  List<TEntity> UpdateRange(List<TEntity> entities)
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
    }

}
