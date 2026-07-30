using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostLikeGetDetailRequest : IRequest<PostLikeGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class PostLikeGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
