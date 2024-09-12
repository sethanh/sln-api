using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SectionTaskCreateRequest : IRequest<SectionTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class SectionTaskCreateResponse
{
    public required string Name { get; set; }
}
