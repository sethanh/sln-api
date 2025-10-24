using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationAccountCreateRequest : IRequest<ConversationAccountCreateResponse>
{
    public required string Name { get; set; }
}

public class ConversationAccountCreateResponse
{
    public required string Name { get; set; }
}
