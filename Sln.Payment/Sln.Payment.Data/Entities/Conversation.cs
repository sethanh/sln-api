using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Conversation : PaymentAuditModel<Guid>
{
    public string? Name { get; set; }
    public virtual ICollection<ConversationAccount>? Accounts { get; set; }
    public string? Background { get; set; }
    public string? Icon { get; set; }
}
