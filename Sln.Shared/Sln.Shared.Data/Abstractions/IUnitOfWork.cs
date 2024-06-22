using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChange();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}