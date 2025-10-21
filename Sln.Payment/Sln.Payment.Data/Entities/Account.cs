using System.ComponentModel.DataAnnotations.Schema;
using Sln.Payment.Data.Models;
using Sln.Shared.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Account : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    [Column(TypeName = "varchar(100)")]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool RootAccount { get; set; } = false;
}
