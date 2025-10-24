using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationAccountGetAllRequest : PaginationRequest, IRequest<ConversationAccountGetAllResponse>
{
}

public class ConversationAccountGetAllResponse : PaginationResponse<ConversationAccountGetAllResponseItem>
{
}

public class ConversationAccountGetAllResponseItem : ConversationAccountGetDetailResponse
{
}