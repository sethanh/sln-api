using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class SocialContactCreateHandler(SocialContactService socialContactService) : IRequestHandler<SocialContactCreateRequest, SocialContactCreateResponse>
{
    public Task<SocialContactCreateResponse> Handle(SocialContactCreateRequest request, CancellationToken cancellationToken)
    {
        return socialContactService.Create(request);
    }
}