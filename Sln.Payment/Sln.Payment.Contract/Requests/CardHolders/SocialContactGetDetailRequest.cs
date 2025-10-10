using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Enums;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactGetDetailRequest : IRequest<SocialContactGetDetailResponse>
{
    public required long Id { get; set; }
}

public class SocialContactGetDetailResponse
{
    public required long Id { get; set; }
    public required long ContactId { get; set; }
    public string? Link { get; set; }
    public SocialType? SocialType { get; set;}
}
