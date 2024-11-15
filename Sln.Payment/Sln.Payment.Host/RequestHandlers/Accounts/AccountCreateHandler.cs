using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountCreateHandler(AccountService accountService) : IRequestHandler<AccountCreateRequest, AccountCreateResponse>
{
    public Task<AccountCreateResponse> Handle(AccountCreateRequest request, CancellationToken cancellationToken)
    {
        return accountService.Create(request);
    }
}