using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationCreateHandler(ConversationService conversationService) : IRequestHandler<ConversationCreateRequest, ConversationCreateResponse>
{
    public Task<ConversationCreateResponse> Handle(ConversationCreateRequest request, CancellationToken cancellationToken)
    {
        return conversationService.Create(request);
    }
}