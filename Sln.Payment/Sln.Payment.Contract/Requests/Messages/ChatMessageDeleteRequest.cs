using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}