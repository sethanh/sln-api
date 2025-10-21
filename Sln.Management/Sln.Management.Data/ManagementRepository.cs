using Sln.Management.Common.Models;
using Sln.Shared.Data;
using Sln.Shared.Data.Interfaces;

namespace Sln.Management.Data
{
    public class ManagementRepository<TEntity>(
        ManagementDbContext context,
        CurrentManagementAccount currentAccount
        ) : RepositoryBase<TEntity, Guid>(context, currentAccount.Id), IRepository<TEntity> where TEntity : class
    {
    }

}
