using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ChatMessageDeleteHandler(ChatMessageService chatMessageService) : IRequestHandler<ChatMessageDeleteRequest>
{
    public Task Handle(ChatMessageDeleteRequest request, CancellationToken cancellationToken)
    {
        return chatMessageService.Delete(request);
    }
}
