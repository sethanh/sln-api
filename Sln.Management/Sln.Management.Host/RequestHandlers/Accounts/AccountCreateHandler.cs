using MediatR;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Business.Services.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts;

public class AccountCreateHandler(AccountService accountService) : IRequestHandler<AccountCreateRequest, AccountCreateResponse>
{
    public Task<AccountCreateResponse> Handle(AccountCreateRequest request, CancellationToken cancellationToken)
    {
        return accountService.Create(request);
    }
}