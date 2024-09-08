using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class EpicTaskGetAllRequest : PaginationRequest, IRequest<EpicTaskGetAllResponse>
{
}

public class EpicTaskGetAllResponse : PaginationResponse<EpicTaskGetAllResponseItem>
{
}

public class EpicTaskGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}