using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class RangeTaskGetDetailRequest : IRequest<RangeTaskGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class RangeTaskGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
