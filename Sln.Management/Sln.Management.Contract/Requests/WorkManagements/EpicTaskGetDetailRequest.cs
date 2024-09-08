using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class EpicTaskGetDetailRequest : IRequest<EpicTaskGetDetailResponse>
{
    public required long Id { get; set; }
}

public class EpicTaskGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
