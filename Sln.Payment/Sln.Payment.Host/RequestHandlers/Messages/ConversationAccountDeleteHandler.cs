using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationAccountDeleteHandler(ConversationAccountService conversationAccountService) : IRequestHandler<ConversationAccountDeleteRequest>
{
    public Task Handle(ConversationAccountDeleteRequest request, CancellationToken cancellationToken)
    {
        return conversationAccountService.Delete(request);
    }
}
