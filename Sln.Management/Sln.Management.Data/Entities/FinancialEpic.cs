using Sln.Management.Data.Models;

namespace Sln.Management.Data.Entities;

public class FinancialEpic : ManagementAuditModel<long>
{
    public required string Name { get; set; }
}
