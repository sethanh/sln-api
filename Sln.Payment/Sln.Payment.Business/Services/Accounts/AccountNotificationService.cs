using Sln.Payment.Contract.Errors.Accounts;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Accounts;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;
using Sln.Shared.Common.Values;
using System.Text.Json;
using Sln.Payment.Business.Services.RealTime;

namespace Sln.Payment.Business.Services.Accounts;

public class AccountNotificationService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountNotificationManager AccountNotificationManager => GetService<AccountNotificationManager>();
    private RealTimeService RealTimeService => GetService<RealTimeService>();

    public Task<AccountNotificationGetAllResponse> GetAll(AccountNotificationGetAllRequest request)
    {
        var AccountNotification = AccountNotificationManager.GetAll().Where(c => c.AccountId == CurrentAccount.Id).OrderByDescending(c => c.CreationTime);

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

        if (accountNotification == null)
        {
            throw new HttpBadRequest(AccountNotificationErrors.ACCOUNT_NOTIFICATION_NOT_FOUND);
        }

        // TODO: Update accountNotification properties
        if (request.ReadAt != null)
        {
            accountNotification.ReadAt = request.ReadAt;
        }

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

    public async Task HandleCreateAccountConnectionNotificationAsync(AccountConnection data, List<AuditDataChange> dataChanges)
    {
        var AccountRequest = data.AccountRequest;
        var AccountAccept = data.AccountAccept;

        var notification = AccountNotificationManager.Add(new AccountNotification
        {
            Id = Guid.NewGuid(),
            Title = $"{AccountAccept!.Name}",
            Action = "ACCOUNT_CONNECTION_ACCEPTED",
            Body = $"{AccountAccept!.Name} has accepted your friend request.",
            ReferenceId = data.Id,
            ReferenceObjectName = nameof(AccountConnection),
            AccountId = AccountRequest!.Id,
            BodyJson = JsonSerializer.Serialize(new
            {

                Id = Guid.NewGuid(),
                Title = $"{AccountAccept!.Name}",
                Action = "ACCOUNT_CONNECTION_ACCEPTED",
                Body = $"{AccountAccept!.Name} has accepted your friend request.",
                ReferenceId = data.Id,
                ReferenceObjectName = nameof(AccountConnection),
                AccountId = AccountRequest!.Id,
                AccountAccept = new
                {
                    Photo = AccountAccept.Photo,
                    GoogleAccounts = AccountAccept.GoogleAccounts?.Select(ga => ga.Picture).ToList()
                }
            }),
        });

        await UnitOfWork.SaveChangesAsync();

        await RealTimeService.PublishAccountConnectionNotification(notification);
    }
}
