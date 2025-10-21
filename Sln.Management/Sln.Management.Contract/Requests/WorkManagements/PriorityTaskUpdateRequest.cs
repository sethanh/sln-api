using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class PriorityTaskUpdateRequest : IRequest<PriorityTaskUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class PriorityTaskUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
