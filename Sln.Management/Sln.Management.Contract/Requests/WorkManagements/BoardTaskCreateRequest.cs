using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class BoardTaskCreateRequest : IRequest<BoardTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class BoardTaskCreateResponse
{
    public required string Name { get; set; }
}
