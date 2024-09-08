using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class TaskManagementCreateRequest : IRequest<TaskManagementCreateResponse>
{
    public required string Name { get; set; }
}

public class TaskManagementCreateResponse
{
    public required string Name { get; set; }
}
