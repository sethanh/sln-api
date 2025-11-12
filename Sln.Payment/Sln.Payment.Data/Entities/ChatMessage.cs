using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class ChatMessage : PaymentAuditModel<Guid>
{
    public Guid ConversationId { get; set; }
    public Guid AccountId { get; set; }
    public virtual Account? Account { get; set; }
    public required string Message { get; set; }
}
