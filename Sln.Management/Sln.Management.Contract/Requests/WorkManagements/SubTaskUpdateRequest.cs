using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SubTaskUpdateRequest : IRequest<SubTaskUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class SubTaskUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
