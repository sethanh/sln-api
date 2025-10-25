using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class AccountConnectionCreateHandler(AccountConnectionService accountConnectionService) : IRequestHandler<AccountConnectionCreateRequest, AccountConnectionCreateResponse>
{
    public Task<AccountConnectionCreateResponse> Handle(AccountConnectionCreateRequest request, CancellationToken cancellationToken)
    {
        return accountConnectionService.Create(request);
    }
}