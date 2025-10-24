using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageGetDetailRequest : IRequest<ChatMessageGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ChatMessageGetDetailResponse
{
    public required Guid Id { get; set; }    
    public Guid ConversationId { get; set; }
    public Guid CreatedId { get; set; }
    public DateTime CreationTime { get; set; }
    public required string Message { get; set; }
    public Guid AccountId { get; set; }
    public AccountResponse? Account { get; set; }
}
