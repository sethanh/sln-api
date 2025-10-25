using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class AccountConnectionGetDetailHandler(AccountConnectionService accountConnectionService) : IRequestHandler<AccountConnectionGetDetailRequest, AccountConnectionGetDetailResponse>
{
    public Task<AccountConnectionGetDetailResponse> Handle(AccountConnectionGetDetailRequest request, CancellationToken cancellationToken)
    {
        return accountConnectionService.GetDetail(request);
    }
}
