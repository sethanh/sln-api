using Sln.Payment.Contract.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class ProductCategory : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    public ProductType Type { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
