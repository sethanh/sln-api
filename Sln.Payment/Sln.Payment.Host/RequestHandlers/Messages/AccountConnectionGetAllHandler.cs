using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class AccountConnectionGetAllHandler(AccountConnectionService accountConnectionService) : IRequestHandler<AccountConnectionGetAllRequest, AccountConnectionGetAllResponse>
{
    public Task<AccountConnectionGetAllResponse> Handle(AccountConnectionGetAllRequest request, CancellationToken cancellationToken)
    {
        return accountConnectionService.GetAll(request);
    }
}
