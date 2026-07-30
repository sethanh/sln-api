using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class CommentCreateRequest : IRequest<CommentCreateResponse>
{
    public required string Name { get; set; }
}

public class CommentCreateResponse
{
    public required string Name { get; set; }
}
