using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class SocialContactGetDetailHandler(SocialContactService socialContactService) : IRequestHandler<SocialContactGetDetailRequest, SocialContactGetDetailResponse>
{
    public Task<SocialContactGetDetailResponse> Handle(SocialContactGetDetailRequest request, CancellationToken cancellationToken)
    {
        return socialContactService.GetDetail(request);
    }
}
