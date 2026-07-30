using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class PostDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}