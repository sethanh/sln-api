using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Uploads;

public class PhotoDeleteRequest: IRequest
{
    public long Id { get; set; }
}