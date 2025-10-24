using MediatR;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Business.Services.Messages;

namespace Sln.Payment.Host.RequestHandlers.Messages;

public class ChatMessageGetDetailHandler(ChatMessageService chatMessageService) : IRequestHandler<ChatMessageGetDetailRequest, ChatMessageGetDetailResponse>
{
    public Task<ChatMessageGetDetailResponse> Handle(ChatMessageGetDetailRequest request, CancellationToken cancellationToken)
    {
        return chatMessageService.GetDetail(request);
    }
}
