using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class ImportanceTaskGetAllRequest : PaginationRequest, IRequest<ImportanceTaskGetAllResponse>
{
}

public class ImportanceTaskGetAllResponse : PaginationResponse<ImportanceTaskGetAllResponseItem>
{
}

public class ImportanceTaskGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}