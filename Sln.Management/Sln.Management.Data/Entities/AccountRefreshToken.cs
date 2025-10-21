using System.ComponentModel.DataAnnotations.Schema;
using Sln.Management.Data.Models;
using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Entities;

public class AccountRefreshToken : ManagementAuditModel<Guid>
{
    [Column(TypeName = "varchar(100)")]
    public required string AccountName { get; set; }
    [Column(TypeName = "varchar(150)")]
    public required string RefreshToken { get; set; }
    public required bool IsActive { get; set; } = true;
    public Guid AccountId { get; set; }
    public DateTime ExpiredTime { get; set; }
    public virtual Account? Account { get; set; }
}
