using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class ConversationAccount : PaymentAuditModel<Guid>
{
    public Guid AccountId { get; set; }
    public Guid ConversationId { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Conversation? Conversation { get; set; }
}
