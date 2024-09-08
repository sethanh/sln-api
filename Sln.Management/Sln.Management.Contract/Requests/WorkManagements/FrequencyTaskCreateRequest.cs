using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class FrequencyTaskCreateRequest : IRequest<FrequencyTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class FrequencyTaskCreateResponse
{
    public required string Name { get; set; }
}
