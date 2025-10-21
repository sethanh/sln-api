using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SectionTaskGetAllRequest : PaginationRequest, IRequest<SectionTaskGetAllResponse>
{
}

public class SectionTaskGetAllResponse : PaginationResponse<SectionTaskGetAllResponseItem>
{
}

public class SectionTaskGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}