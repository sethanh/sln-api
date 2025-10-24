using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationAccountGetAllHandler(ConversationAccountService conversationAccountService) : IRequestHandler<ConversationAccountGetAllRequest, ConversationAccountGetAllResponse>
{
    public Task<ConversationAccountGetAllResponse> Handle(ConversationAccountGetAllRequest request, CancellationToken cancellationToken)
    {
        return conversationAccountService.GetAll(request);
    }
}
