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
    public required long Id { get; set; }
    public required string Name { get; set; }
}