using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Common.Values
{
    public class SystemValues
    {

    }
    
    public class AuditDataChange
    {
        public string? Field { get; set; }
        public object? OriginValue { get; set; }
        public object? ChangedValue { get; set; }
    }
}