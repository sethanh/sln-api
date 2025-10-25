using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountNotificationDeleteHandler(AccountNotificationService accountNotificationService) : IRequestHandler<AccountNotificationDeleteRequest>
{
    public Task Handle(AccountNotificationDeleteRequest request, CancellationToken cancellationToken)
    {
        return accountNotificationService.Delete(request);
    }
}
