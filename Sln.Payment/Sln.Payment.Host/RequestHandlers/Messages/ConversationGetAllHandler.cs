using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationGetAllHandler(ConversationService conversationService) : IRequestHandler<ConversationGetAllRequest, ConversationGetAllResponse>
{
    public Task<ConversationGetAllResponse> Handle(ConversationGetAllRequest request, CancellationToken cancellationToken)
    {
        return conversationService.GetAll(request);
    }
}
