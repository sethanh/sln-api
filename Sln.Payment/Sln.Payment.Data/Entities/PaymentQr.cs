using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class PaymentQr : PaymentAuditModel<long>
{
    public string? BinCode { get; set; }
    public string? AccountNo { get; set; }
    public string? AccountName { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<PaymentQrTransaction>? PaymentQrTransactions { get; set; }
}
