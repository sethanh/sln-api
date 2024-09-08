using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskCreateRequest : IRequest<ImportanceTaskCreateResponse>
{
    public required string Name { get; set; }
}

public class ImportanceTaskCreateResponse
{
    public required string Name { get; set; }
}
