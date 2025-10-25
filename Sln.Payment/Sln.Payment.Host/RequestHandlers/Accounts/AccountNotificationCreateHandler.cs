using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountNotificationCreateHandler(AccountNotificationService accountNotificationService) : IRequestHandler<AccountNotificationCreateRequest, AccountNotificationCreateResponse>
{
    public Task<AccountNotificationCreateResponse> Handle(AccountNotificationCreateRequest request, CancellationToken cancellationToken)
    {
        return accountNotificationService.Create(request);
    }
}