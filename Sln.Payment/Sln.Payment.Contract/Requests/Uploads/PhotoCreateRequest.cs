using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoCreateRequest : IRequest<PhotoCreateResponse>
{
    public required IFormFile File { get; set; }
}

public class PhotoCreateResponse
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
