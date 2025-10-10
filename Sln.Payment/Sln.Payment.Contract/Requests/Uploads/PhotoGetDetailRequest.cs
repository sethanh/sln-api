using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoGetDetailRequest : IRequest<PhotoGetDetailResponse>
{
    public required long Id { get; set; }
}

public class PhotoGetDetailResponse
{
    public long Id { get; set; }
    public string? FileName { get; set; }
    public string? RelativePath { get; set; }
    public decimal? Size { get; set; }
    public string? ContentType { get; set; }
}
