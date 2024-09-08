using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class PriorityTaskGetDetailRequest : IRequest<PriorityTaskGetDetailResponse>
{
    public required long Id { get; set; }
}

public class PriorityTaskGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
