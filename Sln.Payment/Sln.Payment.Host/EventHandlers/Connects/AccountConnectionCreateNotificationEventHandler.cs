using Sln.Payment.Business.Services.Accounts;
using Sln.Payment.Data.Entities;
using Sln.Shared.Common.Values;
using Sln.Shared.Data.Events.Handlers;

namespace Sln.Payment.Host.EventHandlers.Connects
{
    public class AccountConnectionCreateNotificationEventHandler(AccountNotificationService accountNotificationService) : ModelModifyEventHandler<AccountConnection>
    {
        protected override async Task Handle(AccountConnection data, List<AuditDataChange> dataChanges, CancellationToken cancellationToken)
        {
            await accountNotificationService.HandleCreateAccountConnectionNotificationAsync(data, dataChanges);
        }
    }
}