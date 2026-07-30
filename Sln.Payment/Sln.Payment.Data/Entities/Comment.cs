using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Comment : PaymentAuditModel<Guid>
{
    public Guid PostId { get; set; }

    public Guid AccountId { get; set; }

    public Guid? ParentCommentId { get; set; }
    public Guid? ReplyToAccountId { get; set; }

    public required string Content { get; set; }

    public int LikeCount { get; set; }

    public int ReplyCount { get; set; }

    public virtual Post? Post { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Account? ReplyToAccount { get; set; }
}
