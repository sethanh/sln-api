using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Data.Abstractions;

namespace Sln.Payment.Data.Entities
{
    public class SeederHistory : ISeederHistory<long>
    {
        public string SeederName { get; set; } = default!;
        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
        public long Id { get ; set; }
    }
}