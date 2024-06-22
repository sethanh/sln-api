using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Entities;

public class Account : AuditModel
{
    public required string Name { get; set; }
}
