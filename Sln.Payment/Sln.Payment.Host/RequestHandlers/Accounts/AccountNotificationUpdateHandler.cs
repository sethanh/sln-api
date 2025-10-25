using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountNotificationUpdateHandler(AccountNotificationService accountNotificationService) : IRequestHandler<AccountNotificationUpdateRequest, AccountNotificationUpdateResponse>
{
    public Task<AccountNotificationUpdateResponse> Handle(AccountNotificationUpdateRequest request, CancellationToken cancellationToken)
    {
        return accountNotificationService.Update(request);
    }
}