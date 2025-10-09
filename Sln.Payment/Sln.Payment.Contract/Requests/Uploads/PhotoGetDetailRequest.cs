using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoGetDetailRequest : IRequest<PhotoGetDetailResponse>
{
    public required long Id { get; set; }
}

public class PhotoGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
