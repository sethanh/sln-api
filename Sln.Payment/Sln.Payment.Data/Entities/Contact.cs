using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Contact : PaymentAuditModel<long>
{
    public required string Name { get; set; }
    public string? Job { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public long? PhotoId { get; set; }
    public ICollection<SocialContact>? SocialContacts { get; set; }
    public virtual Photo? Photo { get; set;}
}
