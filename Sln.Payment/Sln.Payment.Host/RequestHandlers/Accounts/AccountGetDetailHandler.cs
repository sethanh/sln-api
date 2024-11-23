using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Business.Services.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts;

public class AccountGetDetailHandler(AccountService accountService) : IRequestHandler<AccountGetDetailRequest, AccountGetDetailResponse>
{
    public Task<AccountGetDetailResponse> Handle(AccountGetDetailRequest request, CancellationToken cancellationToken)
    {
        return accountService.GetDetail(request);
    }
}

public class CurrentAccountGetDetailHandler(AccountService accountService) : IRequestHandler<CurrentAccountGetDetailRequest, AccountGetDetailResponse>
{
    public Task<AccountGetDetailResponse> Handle(CurrentAccountGetDetailRequest request, CancellationToken cancellationToken)
    {
        return accountService.GetCurrentAccount(request);
    }
}
