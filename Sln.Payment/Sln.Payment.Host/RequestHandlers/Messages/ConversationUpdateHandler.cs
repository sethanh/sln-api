using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationUpdateHandler(ConversationService conversationService) : IRequestHandler<ConversationUpdateRequest, ConversationUpdateResponse>
{
    public Task<ConversationUpdateResponse> Handle(ConversationUpdateRequest request, CancellationToken cancellationToken)
    {
        return conversationService.Update(request);
    }
}