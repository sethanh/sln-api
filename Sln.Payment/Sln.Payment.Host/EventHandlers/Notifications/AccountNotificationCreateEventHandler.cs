using Sln.Payment.Business.Services.Accounts;
using Sln.Payment.Data.Entities;
using Sln.Shared.Common.Values;
using Sln.Shared.Data.Events.Handlers;

namespace Sln.Payment.Host.EventHandlers.Notifications;

public class AccountNotificationCreateEventHandler(AccountNotificationService NotificationService) : ModelCreateEventHandler<Conversation>
{
    protected override async Task Handle(Conversation data, List<AuditDataChange> dataChanges, CancellationToken cancellationToken)
    {
        await NotificationService.HandleCreateAccountConnectionNotificationAsync(data, dataChanges);
    }
}