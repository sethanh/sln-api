using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface ICreationAuditModel
    {
    }

    public interface ICreationAuditModel<TID> : ICreationAuditModel where TID : struct
    {
        TID? CreatedId {  get; set; }
        DateTime CreationTime { get; set; }
    }
}