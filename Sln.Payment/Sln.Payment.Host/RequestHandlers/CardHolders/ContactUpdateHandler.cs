using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class ContactUpdateHandler(ContactService contactService) : IRequestHandler<ContactUpdateRequest, ContactUpdateResponse>
{
    public Task<ContactUpdateResponse> Handle(ContactUpdateRequest request, CancellationToken cancellationToken)
    {
        return contactService.Update(request);
    }
}