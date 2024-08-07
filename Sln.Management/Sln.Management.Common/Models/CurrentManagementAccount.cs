using Sln.Shared.Common.Services;

namespace Sln.Management.Common.Models
{
    public class CurrentManagementAccount : ICurrentAccount
    {
        public long? Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public long? OrganizationId { get; set; }
        public string? Role { get; set; }
    }
}