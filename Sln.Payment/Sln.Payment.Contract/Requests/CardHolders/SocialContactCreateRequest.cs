using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactCreateRequest : IRequest<SocialContactCreateResponse>
{
    public Guid? Id { get; set; }
    public Guid? ContactId { get; set; }
    public string? Link { get; set; }
    public SocialType? SocialType { get; set;}
}

public class SocialContactCreateResponse
{
    public required string Name { get; set; }
}
