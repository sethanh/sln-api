using MediatR;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Business.Services.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts;

public class AccountUpdateHandler(AccountService accountService) : IRequestHandler<AccountUpdateRequest, AccountUpdateResponse>
{
    public Task<AccountUpdateResponse> Handle(AccountUpdateRequest request, CancellationToken cancellationToken)
    {
        return accountService.Update(request);
    }
}