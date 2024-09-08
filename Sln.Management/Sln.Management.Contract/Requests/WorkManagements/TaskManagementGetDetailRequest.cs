using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class TaskManagementGetDetailRequest : IRequest<TaskManagementGetDetailResponse>
{
    public required long Id { get; set; }
}

public class TaskManagementGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
