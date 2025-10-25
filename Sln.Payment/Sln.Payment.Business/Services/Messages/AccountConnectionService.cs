using Sln.Payment.Contract.Errors.Messages;
using Sln.Payment.Contract.Requests.Messages;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Messages;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;
using Sln.Payment.Contract.Enums;
using Sln.Payment.Business.Managers.Accounts;

namespace Sln.Payment.Business.Services.Messages;

public class AccountConnectionService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountConnectionManager AccountConnectionManager => GetService<AccountConnectionManager>();
    private AccountManager AccountManager => GetService<AccountManager>();

    public Task<AccountConnectionGetAllResponse> GetAll(AccountConnectionGetAllRequest request)
    {
        var accountConnections = AccountConnectionManager.GetAll().Where(c => c.Status == AccountConnectionStatus.Accepted)
            .Where(c => c.AccountAcceptId == CurrentAccount.Id || c.AccountRequestId == CurrentAccount.Id)
            .ToList();

        var accountIds = accountConnections.Select(c => c.AccountAcceptId).Distinct().ToList();
        accountIds.AddRange([.. accountConnections.Select(c => c.AccountRequestId).Distinct()]);

        accountIds = [.. accountIds.Where(c => c != CurrentAccount.Id).Distinct()];

        var Account = AccountManager.GetAll().Where(c => accountIds.Contains(c.Id));
        
        var paginationResponse = PaginationResponse<Account>.Create(
            Account,
            request
        );

        return Task.FromResult(Mapper.Map<AccountConnectionGetAllResponse>(paginationResponse));
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

        if(accountConnection == null)
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
