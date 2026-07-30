using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class PostLike : PaymentAuditModel<Guid>
{
    public Guid PostId { get; set; }

    public Guid AccountId { get; set; }

    public virtual Post? Post { get; set; } 

    public virtual Account? Account { get; set; }
}
