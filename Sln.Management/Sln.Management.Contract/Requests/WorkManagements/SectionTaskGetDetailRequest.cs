using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SectionTaskGetDetailRequest : IRequest<SectionTaskGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class SectionTaskGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
