using Sln.Management.Data.Models;
using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Entities;

public class AccountRefreshToken : ManagementAuditModel
{
    public required string Name { get; set; }
}
