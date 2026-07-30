using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostCreateRequest : IRequest<PostCreateResponse>
{
    public required string Name { get; set; }
}

public class PostCreateResponse
{
    public required string Name { get; set; }
}
