using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class ContactDeleteHandler(ContactService contactService) : IRequestHandler<ContactDeleteRequest>
{
    public Task Handle(ContactDeleteRequest request, CancellationToken cancellationToken)
    {
        return contactService.Delete(request);
    }
}
