using Sln.Payment.Contract.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Sale : PaymentAuditModel<Guid>
{
    public required string Code { get; set; }
    public required DateTime Date { get; set; }
    public DateTime? CheckoutAt { get; set; }
    public bool IsDisplay { get; set; } = true;
    public decimal SubTotalDetail { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TipAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public string? CancelNote { get; set; }
    public SaleType Type { get; set; }
    public virtual ICollection<SaleDetail>? SaleDetails { get; set; }
    public List<Guid> FacilityIds { get; set; } = [];
}
