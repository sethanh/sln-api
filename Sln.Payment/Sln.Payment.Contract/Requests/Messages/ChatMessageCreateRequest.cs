using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageCreateRequest : IRequest<ChatMessageCreateResponse>
{
    public required string Name { get; set; }
}

public class ChatMessageCreateResponse
{
    public required string Name { get; set; }
}
