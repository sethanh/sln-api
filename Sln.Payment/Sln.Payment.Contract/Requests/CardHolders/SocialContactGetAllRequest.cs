using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactGetAllRequest : PaginationRequest, IRequest<SocialContactGetAllResponse>
{
}

public class SocialContactGetAllResponse : PaginationResponse<SocialContactGetAllResponseItem>
{
}

public class SocialContactGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}