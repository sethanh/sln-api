using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoGetAllRequest : PaginationRequest, IRequest<PhotoGetAllResponse>
{
}

public class PhotoGetAllResponse : PaginationResponse<PhotoGetAllResponseItem>
{
}

public class PhotoGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}