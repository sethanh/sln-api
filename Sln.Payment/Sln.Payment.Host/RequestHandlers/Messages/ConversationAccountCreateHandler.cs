using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationAccountCreateHandler(ConversationAccountService conversationAccountService) : IRequestHandler<ConversationAccountCreateRequest, ConversationAccountCreateResponse>
{
    public Task<ConversationAccountCreateResponse> Handle(ConversationAccountCreateRequest request, CancellationToken cancellationToken)
    {
        return conversationAccountService.Create(request);
    }
}