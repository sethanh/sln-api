using Sln.Payment.Contract.Errors.Messages;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Messages;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;
using Sln.Payment.Business.Services.RealTime;

namespace Sln.Payment.Business.Services.Messages;

public class ChatMessageService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ChatMessageManager ChatMessageManager => GetService<ChatMessageManager>();
    private RealTimeService RealTimeService => GetService<RealTimeService>();

    public Task<ChatMessageGetAllResponse> GetAll(ChatMessageGetAllRequest request)
    {
        var ChatMessage = ChatMessageManager.GetAll();

        var paginationResponse = PaginationResponse<ChatMessage>.Create(
            ChatMessage,
            request
        );

        return Task.FromResult(Mapper.Map<ChatMessageGetAllResponse>(paginationResponse));
    }

    public Task<ChatMessageGetDetailResponse> GetDetail(ChatMessageGetDetailRequest request)
    {
        var chatMessage = ChatMessageManager.FirstOrDefault(o => o.Id == request.Id);

        if (chatMessage == null)
        {
            throw new HttpNotFound(ChatMessageErrors.CHAT_MESSAGE_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ChatMessageGetDetailResponse>(chatMessage));
    }

    public async Task<ChatMessageCreateResponse> Create(ChatMessageCreateRequest request)
    {
        var chatMessage = Mapper.Map<ChatMessage>(request);

        ChatMessageManager.Add(chatMessage);

        await UnitOfWork.SaveChangesAsync();

        await RealTimeService.ChatMessageRefresh(chatMessage);

        return Mapper.Map<ChatMessageCreateResponse>(chatMessage);
    }

    public async Task<ChatMessageUpdateResponse> Update(ChatMessageUpdateRequest request)
    {
        var chatMessage = ChatMessageManager.FirstOrDefault(o => o.Id == request.Id);

        if(chatMessage == null)
        {
            throw new HttpBadRequest(ChatMessageErrors.CHAT_MESSAGE_NOT_FOUND);
        }

        // TODO: Update chatMessage properties

        var updateChatMessage = request.Adapt(chatMessage);

        ChatMessageManager.Update(updateChatMessage);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ChatMessageUpdateResponse>(updateChatMessage);
    }

    public async Task Delete(ChatMessageDeleteRequest request)
    {
        var chatMessage = ChatMessageManager.FirstOrDefault(o => o.Id == request.Id);

        if (chatMessage == null)
        {
            throw new HttpNotFound(ChatMessageErrors.CHAT_MESSAGE_NOT_FOUND);
        }

        ChatMessageManager.Delete(chatMessage);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
