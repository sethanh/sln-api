using Sln.Shared.Common.Interfaces;

namespace Sln.Management.Common.Models
{
    public class CurrentManagementAccount : ICurrentAccount
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public Guid? OrganizationId { get; set; }
        public string? Role { get; set; }
    }
}