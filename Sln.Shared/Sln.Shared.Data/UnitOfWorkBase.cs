using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data
{
    public abstract class UnitOfWorkBase<TContext>(
        TContext context
    ) : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context = context;

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public virtual void Dispose()
        {
            _context.Database.CurrentTransaction?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}