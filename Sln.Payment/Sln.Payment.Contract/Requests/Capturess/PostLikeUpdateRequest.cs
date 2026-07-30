using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostLikeUpdateRequest : IRequest<PostLikeUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class PostLikeUpdateResponse :PostLikeGetDetailResponse
{
}
