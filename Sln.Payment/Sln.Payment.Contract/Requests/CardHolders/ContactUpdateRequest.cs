using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactUpdateRequest : IRequest<ContactUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class ContactUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
