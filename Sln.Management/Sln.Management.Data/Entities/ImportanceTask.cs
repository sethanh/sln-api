using Sln.Management.Data.Models;

namespace Sln.Management.Data.Entities;

public class ImportanceTask : ManagementAuditModel<Guid>
{
    public required string Name { get; set; }
}
