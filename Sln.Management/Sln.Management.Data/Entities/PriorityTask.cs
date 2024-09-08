using Sln.Management.Data.Models;

namespace Sln.Management.Data.Entities;

public class PriorityTask : ManagementAuditModel<long>
{
    public required string Name { get; set; }
}
