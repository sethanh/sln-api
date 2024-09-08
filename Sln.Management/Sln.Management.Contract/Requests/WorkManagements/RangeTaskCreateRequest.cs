using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class RangeTaskCreateRequest : IRequest<RangeTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class RangeTaskCreateResponse
{
    public required string Name { get; set; }
}
