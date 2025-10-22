using Sln.Payment.Contract.Enums;
using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class SaleDetail : PaymentAuditModel<Guid>
{
    public required Guid ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public required Guid SaleId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public required string Name { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Sale? Sale { get; set; }
}
