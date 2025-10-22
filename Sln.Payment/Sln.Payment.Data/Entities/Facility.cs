using Sln.Payment.Data.Models;

namespace Sln.Payment.Data.Entities;

public class Facility : PaymentAuditModel<Guid>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
