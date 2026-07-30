using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostLikeCreateRequest : IRequest<PostLikeCreateResponse>
{
    public required string Name { get; set; }
}

public class PostLikeCreateResponse
{
    public required string Name { get; set; }
}
