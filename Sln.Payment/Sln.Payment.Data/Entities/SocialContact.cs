using Sln.Payment.Common.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class SocialContact : PaymentAuditModel<long>
{
    public required long ContactId { get; set; }
    public string? Link { get; set; }
    public virtual Contact? Contact { get; set; }
    public SocialType? SocialType { get; set;}
}
