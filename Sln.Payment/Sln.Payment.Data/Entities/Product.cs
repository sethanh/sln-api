using Sln.Payment.Contract.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Product : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    public Guid? ProductCategoryId { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public required string Code { get; set; }
    public decimal? OriginalPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public int? Duration { get; set; }
    public virtual ProductCategory? ProductCategory { get; set; }
    public ProductType Type { get; set; }
    public virtual ICollection<SaleDetail>? SaleDetails { get; set; }
}
