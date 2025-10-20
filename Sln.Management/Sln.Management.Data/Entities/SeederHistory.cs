using Sln.Shared.Data.Abstractions;
using Sln.Shared.Data.Interfaces;

namespace Sln.Management.Data.Entities
{
    public class SeederHistory : ISeederHistory<long>
    {

        public string SeederName { get; set; } = default!;
        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
        public long Id { get ; set ; }
    }
}