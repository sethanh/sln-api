using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface ICreationAuditModel
    {
        DateTime CreationTime { get; set; }
        long? CreatedId {  get; set; }
    }
}