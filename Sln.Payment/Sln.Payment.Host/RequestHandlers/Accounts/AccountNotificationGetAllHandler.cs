using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountNotificationGetAllHandler(AccountNotificationService accountNotificationService) : IRequestHandler<AccountNotificationGetAllRequest, AccountNotificationGetAllResponse>
{
    public Task<AccountNotificationGetAllResponse> Handle(AccountNotificationGetAllRequest request, CancellationToken cancellationToken)
    {
        return accountNotificationService.GetAll(request);
    }
}
