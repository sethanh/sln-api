using Sln.Payment.Contract.Errors.Accounts;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Accounts;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Accounts;

public class AccountNotificationService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountNotificationManager AccountNotificationManager => GetService<AccountNotificationManager>();

    public Task<AccountNotificationGetAllResponse> GetAll(AccountNotificationGetAllRequest request)
    {
        var AccountNotification = AccountNotificationManager.GetAll().Where(c => c.AccountId == CurrentAccount.Id);

        var paginationResponse = PaginationResponse<AccountNotification>.Create(
            AccountNotification,
            request
        );

        return Task.FromResult(Mapper.Map<AccountNotificationGetAllResponse>(paginationResponse));
    }

    public Task<AccountNotificationGetDetailResponse> GetDetail(AccountNotificationGetDetailRequest request)
    {
        var accountNotification = AccountNotificationManager.FirstOrDefault(o => o.Id == request.Id);

        if (accountNotification == null)
        {
            throw new HttpNotFound(AccountNotificationErrors.ACCOUNT_NOTIFICATION_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<AccountNotificationGetDetailResponse>(accountNotification));
    }

    public async Task<AccountNotificationCreateResponse> Create(AccountNotificationCreateRequest request)
    {
        var accountNotification = Mapper.Map<AccountNotification>(request);

        AccountNotificationManager.Add(accountNotification);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountNotificationCreateResponse>(accountNotification);
    }

    public async Task<AccountNotificationUpdateResponse> Update(AccountNotificationUpdateRequest request)
    {
        var accountNotification = AccountNotificationManager.FirstOrDefault(o => o.Id == request.Id);

        if(accountNotification == null)
        {
            throw new HttpBadRequest(AccountNotificationErrors.ACCOUNT_NOTIFICATION_NOT_FOUND);
        }

        // TODO: Update accountNotification properties

        var updateAccountNotification = request.Adapt(accountNotification);

        AccountNotificationManager.Update(updateAccountNotification);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountNotificationUpdateResponse>(updateAccountNotification);
    }

    public async Task Delete(AccountNotificationDeleteRequest request)
    {
        var accountNotification = AccountNotificationManager.FirstOrDefault(o => o.Id == request.Id);

        if (accountNotification == null)
        {
            throw new HttpNotFound(AccountNotificationErrors.ACCOUNT_NOTIFICATION_NOT_FOUND);
        }

        AccountNotificationManager.Delete(accountNotification);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
