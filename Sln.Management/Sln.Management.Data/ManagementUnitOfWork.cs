using MediatR;
using Sln.Shared.Data;

namespace Sln.Management.Data
{
    public class ManagementUnitOfWork(
    ManagementDbContext context,
    IPublisher publisher
    ) : UnitOfWorkBase<ManagementDbContext>(context, publisher)
{
}
}