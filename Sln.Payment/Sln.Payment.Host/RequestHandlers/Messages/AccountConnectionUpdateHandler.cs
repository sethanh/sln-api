using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class AccountConnectionUpdateHandler(AccountConnectionService accountConnectionService) : IRequestHandler<AccountConnectionUpdateRequest, AccountConnectionUpdateResponse>
{
    public Task<AccountConnectionUpdateResponse> Handle(AccountConnectionUpdateRequest request, CancellationToken cancellationToken)
    {
        return accountConnectionService.Update(request);
    }
}