using Sln.Payment.Data.Models;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Data.Entities;

public class SocialContact : PaymentAuditModel<Guid>
{
    public required Guid ContactId { get; set; }
    public string? Link { get; set; }
    public virtual Contact? Contact { get; set; }
    public SocialType? SocialType { get; set;}
}
