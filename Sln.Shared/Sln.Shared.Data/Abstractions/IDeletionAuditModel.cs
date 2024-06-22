using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IDeletionAuditModel
    {
        DateTime? DeletionTime { get; set; }
        long? DeletedId { get; set; }
        bool IsDeleted { get; set; }
    }
}