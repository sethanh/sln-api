using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class SubTaskCreateRequest : IRequest<SubTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class SubTaskCreateResponse
{
    public required string Name { get; set; }
}
