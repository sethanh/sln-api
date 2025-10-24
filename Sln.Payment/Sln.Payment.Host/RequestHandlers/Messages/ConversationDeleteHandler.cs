using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationDeleteHandler(ConversationService conversationService) : IRequestHandler<ConversationDeleteRequest>
{
    public Task Handle(ConversationDeleteRequest request, CancellationToken cancellationToken)
    {
        return conversationService.Delete(request);
    }
}
