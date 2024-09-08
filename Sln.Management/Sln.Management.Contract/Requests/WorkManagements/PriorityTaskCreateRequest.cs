using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class PriorityTaskCreateRequest : IRequest<PriorityTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class PriorityTaskCreateResponse
{
    public required string Name { get; set; }
}
