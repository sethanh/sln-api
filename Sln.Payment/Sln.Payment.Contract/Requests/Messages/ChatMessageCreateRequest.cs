using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageCreateRequest : IRequest<ChatMessageCreateResponse>
{
    public required string Message { get; set; }
    public Guid AccountId { get; set; }
    public Guid ConversationId { get; set; }
}

public class ChatMessageCreateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Message { get; set; }
    public Guid AccountId { get; set; }
    public Guid ConversationId { get; set; }
}
