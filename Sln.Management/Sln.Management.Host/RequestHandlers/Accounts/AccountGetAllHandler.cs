using MediatR;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Business.Services.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts;

public class AccountGetAllHandler(AccountService accountService) : IRequestHandler<AccountGetAllRequest, AccountGetAllResponse>
{
    public Task<AccountGetAllResponse> Handle(AccountGetAllRequest request, CancellationToken cancellationToken)
    {
        return accountService.GetAll(request);
    }
}
