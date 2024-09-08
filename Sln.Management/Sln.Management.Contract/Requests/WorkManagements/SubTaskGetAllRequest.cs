using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SubTaskGetAllRequest : PaginationRequest, IRequest<SubTaskGetAllResponse>
{
}

public class SubTaskGetAllResponse : PaginationResponse<SubTaskGetAllResponseItem>
{
}

public class SubTaskGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}