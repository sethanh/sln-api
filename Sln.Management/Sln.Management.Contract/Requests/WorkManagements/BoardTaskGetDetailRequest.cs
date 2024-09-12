using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Management.Contract.Requests.WorkManagements;

public class BoardTaskGetDetailRequest : IRequest<BoardTaskGetDetailResponse>
{
    public required long Id { get; set; }
}

public class BoardTaskGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
