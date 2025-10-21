using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactUpdateRequest : IRequest<SocialContactUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class SocialContactUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
