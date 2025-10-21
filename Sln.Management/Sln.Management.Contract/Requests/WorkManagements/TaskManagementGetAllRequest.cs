using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class TaskManagementGetAllRequest : PaginationRequest, IRequest<TaskManagementGetAllResponse>
{
}

public class TaskManagementGetAllResponse : PaginationResponse<TaskManagementGetAllResponseItem>
{
}

public class TaskManagementGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}