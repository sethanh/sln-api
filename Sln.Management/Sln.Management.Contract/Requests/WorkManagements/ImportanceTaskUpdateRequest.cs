using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskUpdateRequest : IRequest<ImportanceTaskUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class ImportanceTaskUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
