using System.ComponentModel.DataAnnotations.Schema;
using Sln.Management.Data.Models;
using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Entities;

public class Account : ManagementAuditModel
{
    public required string Name { get; set; }
    [Column(TypeName = "varchar(100)")]
    public required string Email { get; set; }
    public required string Password { get; set; }
}
