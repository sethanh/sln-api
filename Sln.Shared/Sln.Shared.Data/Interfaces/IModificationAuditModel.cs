using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Interfaces
{
    public interface IModificationAuditModel
    {
    }

    public interface IModificationAuditModel<TID> : IModificationAuditModel where TID : struct
    {
        TID? LastModificationId { get; set; }
        DateTime? LastModificationTime { get; set; }
    }
}