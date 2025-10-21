using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SubTaskUpdateRequest : IRequest<SubTaskUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class SubTaskUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
