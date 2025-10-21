using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SectionTaskUpdateRequest : IRequest<SectionTaskUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class SectionTaskUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
