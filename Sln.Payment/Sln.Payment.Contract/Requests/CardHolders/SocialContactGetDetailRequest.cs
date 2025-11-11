using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactGetDetailRequest : IRequest<SocialContactGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class SocialContactGetDetailResponse
{
    public required Guid Id { get; set; }
    public required Guid ContactId { get; set; }
    public string? Link { get; set; }
    public SocialType? SocialType { get; set; }
}
