using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactCreateRequest : IRequest<ContactCreateResponse>
{
    public required string Name { get; set; }
}

public class ContactCreateResponse
{
    public required string Name { get; set; }
}
