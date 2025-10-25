using System.ComponentModel.DataAnnotations.Schema;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Account : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    [Column(TypeName = "varchar(100)")]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid? PhotoId { get; set; }
    public bool RootAccount { get; set; } = false;
    public virtual ICollection<GoogleAccount>? GoogleAccounts { get; set; }
    public virtual ICollection<ChatMessage>? ChatMessages { get; set; }
    public virtual ICollection<ConversationAccount>? Conversations { get; set; }
    public virtual Photo? Photo { get; set;}
}
