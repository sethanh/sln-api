using Sln.Management.Data.Models;

namespace Sln.Management.Data.Entities;

public class BoardTask : ManagementAuditModel<long>
{
    public required string Name { get; set; }
    public required decimal Total  { get; set; }
}
