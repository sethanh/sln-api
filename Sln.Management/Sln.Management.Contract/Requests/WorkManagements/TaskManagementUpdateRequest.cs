using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class TaskManagementUpdateRequest : IRequest<TaskManagementUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class TaskManagementUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
