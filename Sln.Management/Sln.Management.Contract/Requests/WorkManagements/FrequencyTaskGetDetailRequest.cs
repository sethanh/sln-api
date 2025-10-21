using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class FrequencyTaskGetDetailRequest : IRequest<FrequencyTaskGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class FrequencyTaskGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
