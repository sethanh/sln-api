using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class RangeTaskGetDetailRequest : IRequest<RangeTaskGetDetailResponse>
{
    public required long Id { get; set; }
}

public class RangeTaskGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
