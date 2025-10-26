using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Business
{
    public abstract class DomainServiceBase<TEntity, TKey>(IRepository<TEntity> repository) 
        : IDomainService<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> MainRepository = repository;

        public IQueryable<TEntity> Search(string? searchTerm)
        {
            return MainRepository.Search(searchTerm);
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, string? astFilter)
        {
            return MainRepository.ApplyFilter(source, astFilter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return MainRepository.GetAll();
        }

        public IQueryable<TEntity> GetAll(string? search, string? filter)
        {
            var data = MainRepository.GetAll();
            data = this.Search(search);
            data = this.ApplyFilter(data, filter);

            return data;
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return MainRepository.FirstOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            return MainRepository.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            MainRepository.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return MainRepository.Update(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return MainRepository.Delete(entity);
        }


        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            MainRepository.UpdateRange(entities);
            return entities;
        }

        public List<TEntity> DeleteRange(List<TEntity> entities)
        {
            MainRepository.DeleteRange(entities);
            return entities;
        }

        public List<TEntity> RemoveRange(List<TEntity> entities)
        {
            MainRepository.RemoveRange(entities);
            return entities;
        }
    }
}