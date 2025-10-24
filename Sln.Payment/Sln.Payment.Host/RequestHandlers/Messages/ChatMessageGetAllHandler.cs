using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ChatMessageGetAllHandler(ChatMessageService chatMessageService) : IRequestHandler<ChatMessageGetAllRequest, ChatMessageGetAllResponse>
{
    public Task<ChatMessageGetAllResponse> Handle(ChatMessageGetAllRequest request, CancellationToken cancellationToken)
    {
        return chatMessageService.GetAll(request);
    }
}
