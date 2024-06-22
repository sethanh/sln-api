using MediatR;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Business.Services.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts;

public class AccountGetDetailHandler(AccountService accountService) : IRequestHandler<AccountGetDetailRequest, AccountGetDetailResponse>
{
    public Task<AccountGetDetailResponse> Handle(AccountGetDetailRequest request, CancellationToken cancellationToken)
    {
        return accountService.GetDetail(request);
    }
}
