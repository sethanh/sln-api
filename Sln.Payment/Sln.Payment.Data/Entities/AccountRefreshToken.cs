using System.ComponentModel.DataAnnotations.Schema;
using Sln.Payment.Data.Models;
using Sln.Shared.Data.Models;

namespace Sln.Payment.Data.Entities;

public class AccountRefreshToken : PaymentAuditModel<long>
{
    [Column(TypeName = "varchar(100)")]
    public required string AccountName { get; set; }
    [Column(TypeName = "varchar(150)")]
    public required string RefreshToken { get; set; }
    public required bool IsActive { get; set; } = true;
    public long AccountId { get; set; }
    public DateTime ExpiredTime { get; set; }
    public virtual Account? Account { get; set; }
}
