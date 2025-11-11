using System.ComponentModel.DataAnnotations.Schema;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class GoogleAccount : PaymentAuditModel<Guid>
{
    public string? Name { get; set; }
    public string? Picture { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Email { get; set; }
    public string? Sub { get; set; }
    public Guid? AccountId { get; set; }
    public virtual Account? Account { get; set; }
}
