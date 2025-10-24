using Sln.Payment.Contract.Errors.Messages;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Messages;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Messages;

public class ConversationAccountService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ConversationAccountManager ConversationAccountManager => GetService<ConversationAccountManager>();

    public Task<ConversationAccountGetAllResponse> GetAll(ConversationAccountGetAllRequest request)
    {
        var ConversationAccount = ConversationAccountManager.GetAll();

        var paginationResponse = PaginationResponse<ConversationAccount>.Create(
            ConversationAccount,
            request
        );

        return Task.FromResult(Mapper.Map<ConversationAccountGetAllResponse>(paginationResponse));
    }

    public Task<ConversationAccountGetDetailResponse> GetDetail(ConversationAccountGetDetailRequest request)
    {
        var conversationAccount = ConversationAccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (conversationAccount == null)
        {
            throw new HttpNotFound(ConversationAccountErrors.CONVERSATION_ACCOUNT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ConversationAccountGetDetailResponse>(conversationAccount));
    }

    public async Task<ConversationAccountCreateResponse> Create(ConversationAccountCreateRequest request)
    {
        var conversationAccount = Mapper.Map<ConversationAccount>(request);

        ConversationAccountManager.Add(conversationAccount);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ConversationAccountCreateResponse>(conversationAccount);
    }

    public async Task<ConversationAccountUpdateResponse> Update(ConversationAccountUpdateRequest request)
    {
        var conversationAccount = ConversationAccountManager.FirstOrDefault(o => o.Id == request.Id);

        if(conversationAccount == null)
        {
            throw new HttpBadRequest(ConversationAccountErrors.CONVERSATION_ACCOUNT_NOT_FOUND);
        }

        // TODO: Update conversationAccount properties

        var updateConversationAccount = request.Adapt(conversationAccount);

        ConversationAccountManager.Update(updateConversationAccount);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ConversationAccountUpdateResponse>(updateConversationAccount);
    }

    public async Task Delete(ConversationAccountDeleteRequest request)
    {
        var conversationAccount = ConversationAccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (conversationAccount == null)
        {
            throw new HttpNotFound(ConversationAccountErrors.CONVERSATION_ACCOUNT_NOT_FOUND);
        }

        ConversationAccountManager.Delete(conversationAccount);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
