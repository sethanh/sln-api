using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountDeleteHandler(AccountService accountService) : IRequestHandler<AccountDeleteRequest>
{
    public Task Handle(AccountDeleteRequest request, CancellationToken cancellationToken)
    {
        return accountService.Delete(request);
    }
}
