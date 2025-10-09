using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class SocialContactDeleteHandler(SocialContactService socialContactService) : IRequestHandler<SocialContactDeleteRequest>
{
    public Task Handle(SocialContactDeleteRequest request, CancellationToken cancellationToken)
    {
        return socialContactService.Delete(request);
    }
}
