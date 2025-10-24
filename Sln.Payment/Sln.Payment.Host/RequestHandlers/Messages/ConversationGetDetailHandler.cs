using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationGetDetailHandler(ConversationService conversationService) : IRequestHandler<ConversationGetDetailRequest, ConversationGetDetailResponse>
{
    public Task<ConversationGetDetailResponse> Handle(ConversationGetDetailRequest request, CancellationToken cancellationToken)
    {
        return conversationService.GetDetail(request);
    }
}
