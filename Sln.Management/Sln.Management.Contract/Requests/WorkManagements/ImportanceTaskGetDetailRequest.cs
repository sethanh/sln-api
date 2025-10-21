using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskGetDetailRequest : IRequest<ImportanceTaskGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ImportanceTaskGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
