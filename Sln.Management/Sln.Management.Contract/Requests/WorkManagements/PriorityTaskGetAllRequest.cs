using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class PriorityTaskGetAllRequest : PaginationRequest, IRequest<PriorityTaskGetAllResponse>
{
}

public class PriorityTaskGetAllResponse : PaginationResponse<PriorityTaskGetAllResponseItem>
{
}

public class PriorityTaskGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}