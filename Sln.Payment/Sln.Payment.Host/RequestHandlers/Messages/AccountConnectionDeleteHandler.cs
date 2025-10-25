using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class AccountConnectionDeleteHandler(AccountConnectionService accountConnectionService) : IRequestHandler<AccountConnectionDeleteRequest>
{
    public Task Handle(AccountConnectionDeleteRequest request, CancellationToken cancellationToken)
    {
        return accountConnectionService.Delete(request);
    }
}
