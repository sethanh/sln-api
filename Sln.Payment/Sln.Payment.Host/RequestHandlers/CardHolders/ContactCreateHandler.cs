using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class ContactCreateHandler(ContactService contactService) : IRequestHandler<ContactCreateRequest, ContactCreateResponse>
{
    public Task<ContactCreateResponse> Handle(ContactCreateRequest request, CancellationToken cancellationToken)
    {
        return contactService.Create(request);
    }
}