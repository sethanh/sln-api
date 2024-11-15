using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountGetAllHandler(AccountService accountService) : IRequestHandler<AccountGetAllRequest, AccountGetAllResponse>
{
    public Task<AccountGetAllResponse> Handle(AccountGetAllRequest request, CancellationToken cancellationToken)
    {
        return accountService.GetAll(request);
    }
}
