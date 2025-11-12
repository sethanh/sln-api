using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Photo : PaymentAuditModel<Guid>
{
    public string? FileName { get; set; }
    public string? RelativePath { get; set; }
    public virtual ICollection<Contact>? Contacts { get; set; }
    public decimal? Size { get; set; }
    public string? ContentType { get; set; }
}
