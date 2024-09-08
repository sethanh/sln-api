using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class EpicTaskCreateRequest : IRequest<EpicTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class EpicTaskCreateResponse
{
    public required string Name { get; set; }
}
