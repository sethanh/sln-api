using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ConversationAccountGetDetailHandler(ConversationAccountService conversationAccountService) : IRequestHandler<ConversationAccountGetDetailRequest, ConversationAccountGetDetailResponse>
{
    public Task<ConversationAccountGetDetailResponse> Handle(ConversationAccountGetDetailRequest request, CancellationToken cancellationToken)
    {
        return conversationAccountService.GetDetail(request);
    }
}
