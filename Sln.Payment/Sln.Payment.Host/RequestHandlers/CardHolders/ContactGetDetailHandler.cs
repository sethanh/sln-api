using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class ContactGetDetailHandler(ContactService contactService) : IRequestHandler<ContactGetDetailRequest, ContactGetDetailResponse>
{
    public Task<ContactGetDetailResponse> Handle(ContactGetDetailRequest request, CancellationToken cancellationToken)
    {
        return contactService.GetDetail(request);
    }
}

public class ContactGetByProfileNameHandler(ContactService contactService) : IRequestHandler<ContactGetByProfileNameRequest, ContactGetDetailResponse>
{
    public Task<ContactGetDetailResponse> Handle(ContactGetByProfileNameRequest request, CancellationToken cancellationToken)
    {
        return contactService.GetByProfileName(request);
    }
}
