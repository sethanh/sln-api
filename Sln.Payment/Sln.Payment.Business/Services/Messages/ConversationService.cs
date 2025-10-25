using Sln.Payment.Contract.Errors.Messages;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Messages;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Messages;

public class ConversationService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ConversationManager ConversationManager => GetService<ConversationManager>();

    public Task<ConversationGetAllResponse> GetAll(ConversationGetAllRequest request)
    {
        var Conversation = ConversationManager.GetAll()
            .Where(c => c.Accounts != null && c.Accounts.Any(a => a.AccountId == CurrentAccount.Id));

        var paginationResponse = PaginationResponse<Conversation>.Create(
            Conversation,
            request
        );

        return Task.FromResult(Mapper.Map<ConversationGetAllResponse>(paginationResponse));
    }

    public Task<ConversationGetDetailResponse> GetDetail(ConversationGetDetailRequest request)
    {
        var conversation = ConversationManager.FirstOrDefault(o => o.Id == request.Id);

        if (conversation == null)
        {
            throw new HttpNotFound(ConversationErrors.CONVERSATION_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ConversationGetDetailResponse>(conversation));
    }

    public async Task<ConversationCreateResponse> Create(ConversationCreateRequest request)
    {
        var conversation = Mapper.Map<Conversation>(request);

        ConversationManager.Add(conversation);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ConversationCreateResponse>(conversation);
    }

    public async Task<ConversationUpdateResponse> Update(ConversationUpdateRequest request)
    {
        var conversation = ConversationManager.FirstOrDefault(o => o.Id == request.Id);

        if(conversation == null)
        {
            throw new HttpBadRequest(ConversationErrors.CONVERSATION_NOT_FOUND);
        }

        // TODO: Update conversation properties

        var updateConversation = request.Adapt(conversation);

        ConversationManager.Update(updateConversation);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ConversationUpdateResponse>(updateConversation);
    }

    public async Task Delete(ConversationDeleteRequest request)
    {
        var conversation = ConversationManager.FirstOrDefault(o => o.Id == request.Id);

        if (conversation == null)
        {
            throw new HttpNotFound(ConversationErrors.CONVERSATION_NOT_FOUND);
        }

        ConversationManager.Delete(conversation);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
