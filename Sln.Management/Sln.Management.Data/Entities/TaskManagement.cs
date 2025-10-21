using Sln.Management.Data.Models;

namespace Sln.Management.Data.Entities;

public class TaskManagement : ManagementAuditModel<Guid>
{
    public required string Name { get; set; }
}
