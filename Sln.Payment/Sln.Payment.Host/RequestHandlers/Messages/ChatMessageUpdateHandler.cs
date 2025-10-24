using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ChatMessageUpdateHandler(ChatMessageService chatMessageService) : IRequestHandler<ChatMessageUpdateRequest, ChatMessageUpdateResponse>
{
    public Task<ChatMessageUpdateResponse> Handle(ChatMessageUpdateRequest request, CancellationToken cancellationToken)
    {
        return chatMessageService.Update(request);
    }
}