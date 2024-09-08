using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class RangeTaskUpdateRequest : IRequest<RangeTaskUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class RangeTaskUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
