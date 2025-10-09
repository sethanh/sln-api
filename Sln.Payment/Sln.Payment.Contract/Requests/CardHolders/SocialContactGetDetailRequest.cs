using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactGetDetailRequest : IRequest<SocialContactGetDetailResponse>
{
    public required long Id { get; set; }
}

public class SocialContactGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
