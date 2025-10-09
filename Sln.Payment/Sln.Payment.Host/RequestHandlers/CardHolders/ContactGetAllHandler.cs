using MediatR;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Business.Services.CardHolders;

namespace Sln.Payment.Host.RequestHandlers.CardHolders;

public class ContactGetAllHandler(ContactService contactService) : IRequestHandler<ContactGetAllRequest, ContactGetAllResponse>
{
    public Task<ContactGetAllResponse> Handle(ContactGetAllRequest request, CancellationToken cancellationToken)
    {
        return contactService.GetAll(request);
    }
}
