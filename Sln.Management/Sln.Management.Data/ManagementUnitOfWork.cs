using Sln.Shared.Data;

namespace Sln.Management.Data
{
    public class ManagementUnitOfWork(
    ManagementDbContext context
    ) : UnitOfWorkBase<ManagementDbContext>(context)
{
}
}