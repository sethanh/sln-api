using Sln.Payment.Contract.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class AccountConnection : PaymentAuditModel<Guid>
{
    public Guid? AccountRequestId { get; set; }
    public Guid? AccountAcceptId { get; set; }
    public virtual Account? AccountRequest { get; set; }
    public virtual Account? AccountAccept { get; set; }
    public AccountConnectionStatus Status { get; set; } = AccountConnectionStatus.Wait;
}
