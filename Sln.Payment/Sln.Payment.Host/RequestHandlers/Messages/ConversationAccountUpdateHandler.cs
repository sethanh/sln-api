using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationAccountUpdateHandler(ConversationAccountService conversationAccountService) : IRequestHandler<ConversationAccountUpdateRequest, ConversationAccountUpdateResponse>
{
    public Task<ConversationAccountUpdateResponse> Handle(ConversationAccountUpdateRequest request, CancellationToken cancellationToken)
    {
        return conversationAccountService.Update(request);
    }
}