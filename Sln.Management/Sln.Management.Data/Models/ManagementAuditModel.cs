using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Data.Models;

namespace Sln.Management.Data.Models
{
    public abstract class ManagementAuditModel: AuditModel<long>
    {
    }
}