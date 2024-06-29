using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sln.Management.Business.Services.Accounts;
using Sln.Management.Contract.Requests.Accounts;

namespace Sln.Management.Host.RequestHandlers.Accounts
{
    public class AccountLoginHandler(
        AccountService accountService
        ) : IRequestHandler<AccountLoginRequest, AccountLoginResponse>
    {
        public Task<AccountLoginResponse> Handle(AccountLoginRequest request, CancellationToken cancellationToken)
        {
            return accountService.Login(request);
        }
    }
}