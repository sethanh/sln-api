using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class BoardTaskUpdateRequest : IRequest<BoardTaskUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class BoardTaskUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
