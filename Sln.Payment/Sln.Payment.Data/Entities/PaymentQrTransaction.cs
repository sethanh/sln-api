using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class PaymentQrTransaction : PaymentAuditModel<Guid>
{
    public Guid PaymentQrId { get; set; }
    public string? Description { get; set; }
    public decimal? Amount { get; set; }
    public virtual PaymentQr? PaymentQr { get; set; }
}
