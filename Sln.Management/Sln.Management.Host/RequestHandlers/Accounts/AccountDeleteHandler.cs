using MediatR;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Business.Services.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts;

public class AccountDeleteHandler(AccountService accountService) : IRequestHandler<AccountDeleteRequest>
{
    public Task Handle(AccountDeleteRequest request, CancellationToken cancellationToken)
    {
        return accountService.Delete(request);
    }
}
