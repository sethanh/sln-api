using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class AccountNotification : PaymentAuditModel<Guid>
{
    public string? Title { get; set; }
    public string? Action{ get; set; }
    public string? Body { get; set; }
    public Guid? ReferenceId { get; set; }
    public string? ReferenceObjectName { get; set; }
    public Guid? AccountId { get; set; }
    public virtual Account? Account { get; set; }
    public string? BodyJson { get; set; }
    public DateTime? ReadAt { get; set; }
}
