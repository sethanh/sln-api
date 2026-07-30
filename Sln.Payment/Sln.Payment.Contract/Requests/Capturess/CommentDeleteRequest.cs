using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Capturess;

public class CommentDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}