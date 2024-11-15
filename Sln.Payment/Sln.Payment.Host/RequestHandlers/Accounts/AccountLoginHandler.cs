using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sln.Payment.Business.Services.Accounts;
using Sln.Payment.Contract.Requests.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts
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