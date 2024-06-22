using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IModificationAuditModel
    {
        DateTime? LastModificationTime { get; set; }
        long? LastModificationId { get; set; }
    }
}