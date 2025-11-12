using Sln.Payment.Contract.Errors.Messages;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Messages;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Messages;

public class AccountConnectionService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountConnectionManager AccountConnectionManager => GetService<AccountConnectionManager>();

    public AccountConnectionGetAllResponse GetAll(AccountConnectionGetAllRequest request)
    {

        var accountConnectionQuery = AccountConnectionManager.GetAll();

        if (request.Status != null)
        {
            accountConnectionQuery = accountConnectionQuery.Where(c => c.Status == request.Status);
        }

        if(request.Action != null)
        {
            if (request.Action == AccountAction.Send)
            {
                accountConnectionQuery = accountConnectionQuery.Where(c => c.AccountRequestId == CurrentAccount.Id);
            }

            if(request.Action == AccountAction.receive)
            {
                accountConnectionQuery = accountConnectionQuery.Where(c => c.AccountAcceptId== CurrentAccount.Id);
            }
        } 

        var paginationResponse = PaginationResponse<AccountConnection>.Create(
            accountConnectionQuery,
            request
        );

        return Mapper.Map<AccountConnectionGetAllResponse>(paginationResponse);
    }

    public Task<AccountConnectionGetDetailResponse> GetDetail(AccountConnectionGetDetailRequest request)
    {
        var accountConnection = AccountConnectionManager.FirstOrDefault(o => o.Id == request.Id);

        if (accountConnection == null)
        {
            throw new HttpNotFound(AccountConnectionErrors.ACCOUNT_CONNECTION_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<AccountConnectionGetDetailResponse>(accountConnection));
    }

    public async Task<AccountConnectionCreateResponse> Create(AccountConnectionCreateRequest request)
    {
        var accountConnection = Mapper.Map<AccountConnection>(request);

        AccountConnectionManager.Add(accountConnection);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountConnectionCreateResponse>(accountConnection);
    }

    public async Task<AccountConnectionUpdateResponse> Update(AccountConnectionUpdateRequest request)
    {
        var accountConnection = AccountConnectionManager.FirstOrDefault(o => o.Id == request.Id);

        if (accountConnection == null)
        {
            throw new HttpBadRequest(AccountConnectionErrors.ACCOUNT_CONNECTION_NOT_FOUND);
        }

        // TODO: Update accountConnection properties

        var updateAccountConnection = request.Adapt(accountConnection);

        AccountConnectionManager.Update(updateAccountConnection);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountConnectionUpdateResponse>(updateAccountConnection);
    }

    public async Task Delete(AccountConnectionDeleteRequest request)
    {
        var accountConnection = AccountConnectionManager.FirstOrDefault(o => o.Id == request.Id);

        if (accountConnection == null)
        {
            throw new HttpNotFound(AccountConnectionErrors.ACCOUNT_CONNECTION_NOT_FOUND);
        }

        AccountConnectionManager.Delete(accountConnection);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
