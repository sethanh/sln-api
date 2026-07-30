using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostGetDetailRequest : IRequest<PostGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class PostGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
