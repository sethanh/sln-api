using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Abstractions
{
    public class EventRequest<T> : IEventRequest<T>
    {
        public required T Data { get; set; }
        public List<AuditDataChange>? DataChanges { get; set; }
    }
}