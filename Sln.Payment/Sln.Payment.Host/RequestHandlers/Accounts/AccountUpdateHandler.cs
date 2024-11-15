using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountUpdateHandler(AccountService accountService) : IRequestHandler<AccountUpdateRequest, AccountUpdateResponse>
{
    public Task<AccountUpdateResponse> Handle(AccountUpdateRequest request, CancellationToken cancellationToken)
    {
        return accountService.Update(request);
    }
}