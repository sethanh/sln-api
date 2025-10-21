using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}