using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Photo : PaymentAuditModel<long>
{
    public string FileName { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public virtual ICollection<Contact>? Contacts { get; set;}
}
