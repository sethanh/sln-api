using Sln.Management.Data;

namespace Sln.Management.Job;

public class ManagementJobUnitOfWork(
    ManagementDbContext context
    ) : JobUnitOfWork<ManagementDbContext>(context)
{
}
