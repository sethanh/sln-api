using Sln.Payment.Business.Services.Messages;
using Sln.Payment.Data.Entities;
using Sln.Shared.Common.Values;
using Sln.Shared.Data.Events.Handlers;

namespace Sln.Management.Host.EventHandlers.Account
{
    public class AccountConnectionModifyEventHandler(ConversationService ConversationService) : ModelModifyEventHandler<AccountConnection>
    {
        protected override async Task Handle(AccountConnection data, List<AuditDataChange> dataChanges, CancellationToken cancellationToken)
        {
            await ConversationService.HandleModifyAccountConnectionAsync(data, dataChanges);
        }
    }
}