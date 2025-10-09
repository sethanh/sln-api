using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class SocialContactGetAllHandler(SocialContactService socialContactService) : IRequestHandler<SocialContactGetAllRequest, SocialContactGetAllResponse>
{
    public Task<SocialContactGetAllResponse> Handle(SocialContactGetAllRequest request, CancellationToken cancellationToken)
    {
        return socialContactService.GetAll(request);
    }
}
