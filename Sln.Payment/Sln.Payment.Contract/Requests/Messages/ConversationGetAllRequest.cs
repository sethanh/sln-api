using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationGetAllRequest : PaginationRequest, IRequest<ConversationGetAllResponse>
{
}

public class ConversationGetAllResponse : PaginationResponse<ConversationGetAllResponseItem>
{
}

public class ConversationGetAllResponseItem : ConversationGetDetailResponse
{
}