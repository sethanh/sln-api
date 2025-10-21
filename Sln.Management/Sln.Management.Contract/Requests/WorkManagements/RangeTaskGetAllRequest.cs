using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class RangeTaskGetAllRequest : PaginationRequest, IRequest<RangeTaskGetAllResponse>
{
}

public class RangeTaskGetAllResponse : PaginationResponse<RangeTaskGetAllResponseItem>
{
}

public class RangeTaskGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}