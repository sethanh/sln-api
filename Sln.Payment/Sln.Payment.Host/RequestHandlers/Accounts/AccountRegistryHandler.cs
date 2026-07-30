using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sln.Payment.Business.Services.Accounts;
using Sln.Payment.Contract.Requests.Accounts;

namespace Sln.Payment.Host.RequestHandlers.Accounts
{
    public class AccountRegistryHandler(
        AccountService accountService
        ) : IRequestHandler<AccountRegistryRequest, AccountRegistryResponse>
    {
        public Task<AccountRegistryResponse> Handle(AccountRegistryRequest request, CancellationToken cancellationToken)
        {
            return accountService.Registry(request);
        }
    }
}