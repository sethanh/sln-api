using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class SocialContactUpdateHandler(SocialContactService socialContactService) : IRequestHandler<SocialContactUpdateRequest, SocialContactUpdateResponse>
{
    public Task<SocialContactUpdateResponse> Handle(SocialContactUpdateRequest request, CancellationToken cancellationToken)
    {
        return socialContactService.Update(request);
    }
}