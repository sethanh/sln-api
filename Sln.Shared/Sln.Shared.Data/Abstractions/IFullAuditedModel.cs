using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IFullAuditedModel
    {}
    public interface IFullAuditedModel<TID>: ICreationAuditModel<TID>, IModificationAuditModel<TID>, IDeletionAuditModel<TID>, IFullAuditedModel where TID : struct
    {
    }
}