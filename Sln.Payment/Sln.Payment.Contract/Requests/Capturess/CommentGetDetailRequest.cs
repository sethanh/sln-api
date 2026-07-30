using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class CommentGetDetailRequest : IRequest<CommentGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class CommentGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
