using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ChatMessageCreateHandler(ChatMessageService chatMessageService) : IRequestHandler<ChatMessageCreateRequest, ChatMessageCreateResponse>
{
    public Task<ChatMessageCreateResponse> Handle(ChatMessageCreateRequest request, CancellationToken cancellationToken)
    {
        return chatMessageService.Create(request);
    }
}