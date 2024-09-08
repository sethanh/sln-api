using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SubTaskGetDetailRequest : IRequest<SubTaskGetDetailResponse>
{
    public required long Id { get; set; }
}

public class SubTaskGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
