using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactCreateRequest : IRequest<SocialContactCreateResponse>
{
    public required string Name { get; set; }
}

public class SocialContactCreateResponse
{
    public required string Name { get; set; }
}
