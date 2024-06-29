using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IDeletionAuditModel
    {
        bool IsDeleted { get; set; }
    }

    public interface IDeletionAuditModel<TID> : IDeletionAuditModel where TID : struct
    {
        TID? DeletedId { get; set; }
        DateTime? DeletionTime { get; set; }
    }
}