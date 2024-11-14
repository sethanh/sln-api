using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Data.Models;

namespace Sln.Payment.Data.Models
{
    public abstract class PaymentAuditModel<TID>: AuditModel<TID> where TID : struct
    {
    }
}