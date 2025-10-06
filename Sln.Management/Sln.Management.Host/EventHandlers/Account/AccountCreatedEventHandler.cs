using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Common.Values;
using Sln.Shared.Data.Events.Handlers;

namespace Sln.Management.Host.EventHandlers.Account
{
    public class AccountCreatedEventHandler : ModelCreateEventHandler<Data.Entities.Account>
    {
        protected override Task Handle(Data.Entities.Account data, List<AuditDataChange> dataChanges, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}