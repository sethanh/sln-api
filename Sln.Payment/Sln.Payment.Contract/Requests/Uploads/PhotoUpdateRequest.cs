using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoUpdateRequest : IRequest<PhotoUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class PhotoUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
