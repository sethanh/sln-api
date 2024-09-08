using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskUpdateRequest : IRequest<ImportanceTaskUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class ImportanceTaskUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
