using Sln.Shared.Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoCreateRequest : IRequest<PhotoCreateResponse>
{
    public required IFormFile File { get; set; }
}

public class PhotoCreateResponse : PhotoGetDetailResponse
{
}
