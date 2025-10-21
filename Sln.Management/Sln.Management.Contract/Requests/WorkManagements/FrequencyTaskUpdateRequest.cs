using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class FrequencyTaskUpdateRequest : IRequest<FrequencyTaskUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class FrequencyTaskUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
