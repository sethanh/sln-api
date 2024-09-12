using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class BoardTaskGetAllRequest : PaginationRequest, IRequest<BoardTaskGetAllResponse>
{
}

public class BoardTaskGetAllResponse : PaginationResponse<BoardTaskGetAllResponseItem>
{
}

public class BoardTaskGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}