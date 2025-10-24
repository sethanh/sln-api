using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageGetAllRequest : ScrollPaginationRequest, IRequest<ChatMessageGetAllResponse>
{
    public Guid ConversationId { get; set; }
}

public class ChatMessageGetAllResponse : PaginationResponse<ChatMessageGetAllResponseItem>
{
}

public class ChatMessageGetAllResponseItem : ChatMessageGetDetailResponse
{
}