using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class EpicTaskUpdateRequest : IRequest<EpicTaskUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class EpicTaskUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
