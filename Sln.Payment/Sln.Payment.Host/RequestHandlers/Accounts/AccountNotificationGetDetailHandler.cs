using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountNotificationGetDetailHandler(AccountNotificationService accountNotificationService) : IRequestHandler<AccountNotificationGetDetailRequest, AccountNotificationGetDetailResponse>
{
    public Task<AccountNotificationGetDetailResponse> Handle(AccountNotificationGetDetailRequest request, CancellationToken cancellationToken)
    {
        return accountNotificationService.GetDetail(request);
    }
}
