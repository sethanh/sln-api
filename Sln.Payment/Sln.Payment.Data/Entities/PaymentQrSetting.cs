using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class PaymentQrSetting : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
}
