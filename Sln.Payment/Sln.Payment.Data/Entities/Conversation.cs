using Sln.Payment.Data.Models;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Data.Entities;

public class Conversation : PaymentAuditModel<Guid>
{
    public string? Name { get; set; }
    public virtual ICollection<ConversationAccount>? Accounts { get; set; }
    public string? Background { get; set; }
    public string? Icon { get; set; }
    public ConversationType Type { get; set;}
}
