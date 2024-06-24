using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Entities;

public class AccountRefreshToken : AuditModel
{
    public required string Name { get; set; }
}
