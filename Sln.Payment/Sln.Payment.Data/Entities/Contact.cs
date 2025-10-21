using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

[Index(nameof(ProfileName), IsUnique = true)]
public class Contact : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    public string? Job { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid? PhotoId { get; set; }
    public ICollection<SocialContact>? SocialContacts { get; set; }
    public virtual Photo? Photo { get; set; }
    [Column(TypeName = "varchar(88)")]
    public string? ProfileName { get; set; }
}
