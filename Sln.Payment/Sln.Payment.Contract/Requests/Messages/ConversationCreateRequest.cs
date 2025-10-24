using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationCreateRequest : IRequest<ConversationCreateResponse>
{
    public required string Name { get; set; }
}

public class ConversationCreateResponse
{
    public required string Name { get; set; }
}
