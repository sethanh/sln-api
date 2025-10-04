using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Data.Models
{
    public class ChangeIModelEntity
    {
        public EntityState State {get; set;}
        public required object Entity { get; set; }
        public List<AuditDataChange>? DataChanges {get;set;}
    }
}