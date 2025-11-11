using Sln.Scheduler.Contract.Errors.Messages;
using Sln.Scheduler.Contract.Requests.Messages;
using Sln.Scheduler.Data.Entities;
using Sln.Scheduler.Business.Managers.Messages;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;
using Sln.Scheduler.Contract.Enums;
using Sln.Scheduler.Business.Managers.Accounts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc.Filters;
using Sln.Payment.Business.Helpers.Messages;
using Sln.Scheduler.Contract.Requests.Uploads;
using Sln.Scheduler.Contract.Requests.Accounts;

namespace Sln.Scheduler.Business.Services.Messages;

public class AccountConnectionService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountConnectionManager AccountConnectionManager => GetService<AccountConnectionManager>();
    private AccountManager AccountManager => GetService<AccountManager>();

    public Task<AccountConnectionGetAllResponse> GetAll(AccountConnectionGetAllRequest request)
    {

        var accountConnections = AccountConnectionManager.GetAll()
        .Where(c => c.Status == request.Status)
            .ToList();

        if (request.Status == AccountConnectionStatus.Accepted)
        {
            accountConnections = accountConnections
                                .Where(
                                    c => c.AccountAcceptId == CurrentAccount.Id ||
                                    c.AccountRequestId == CurrentAccount.Id)
                                .ToList();
        }

        if (request.Status == AccountConnectionStatus.Wait)
        {
            accountConnections = request.IsSender == true ?
            accountConnections.Where(c => c.AccountRequestId == CurrentAccount.Id).ToList()
            : accountConnections.Where(c => c.AccountAcceptId == CurrentAccount.Id).ToList();
        }

        var options = new RequestOptions
        {
            Status = request.Status,
            IsSender = request.IsSender,
            CurrentAccountId = CurrentAccount.Id
        };

        if (accountConnections.Count != 0)
        {
            var accounts = GetAccountConnectionDetails(
                accountConnections,
                options
            ).AsQueryable();

            var paginationResponse = PaginationResponse<AccountConnectionGetAllResponseItem>.Create(
                accounts,
                request
            );

            return Task.FromResult(Mapper.Map<AccountConnectionGetAllResponse>(paginationResponse));
        }

        return Task.FromResult(new AccountConnectionGetAllResponse());
    }
    
    public List<AccountConnectionGetAllResponseItem> GetAccountConnectionDetails(
        List<AccountConnection> accountConnections,
        RequestOptions options
    )
    {
        var accounts = new List<AccountConnectionGetAllResponseItem>();

        foreach (var connection in accountConnections)
        {
            var account = new AccountConnectionGetAllResponseItem
            {
                ConnectionId = Guid.Empty,
                Id = Guid.Empty,
                Name = string.Empty,
                Email = string.Empty,
                PhotoId = Guid.Empty,
                Photo = null,
                GoogleAccounts = null
            };

            if (AccountConnectionHelper.IsGetAccountAccept(options, connection))
            {
                var acceptedAccount = AccountManager.FirstOrDefault(a => a.Id == connection.AccountAcceptId);

                account = new AccountConnectionGetAllResponseItem
                {
                    Id = acceptedAccount.Id,
                    Name = acceptedAccount.Name,
                    Email = acceptedAccount.Email,
                    PhotoId = acceptedAccount.PhotoId,
                    Photo = acceptedAccount.Photo != null ?
                        Mapper.Map<PhotoGetDetailResponse>(acceptedAccount.Photo) : null,
                    GoogleAccounts = acceptedAccount.GoogleAccounts != null ?
                        Mapper.Map<List<GoogleAccountGetDetailResponse>>(acceptedAccount.GoogleAccounts) : null,
                    ConnectionId = connection.Id
                };
            }
            if (AccountConnectionHelper.IsGetAccountRequest(options, connection))
            {
                var requestedAccount = AccountManager.FirstOrDefault(a => a.Id == connection.AccountRequestId);

                account = new AccountConnectionGetAllResponseItem
                {
                    Id = requestedAccount.Id,
                    Name = requestedAccount.Name,
                    Email = requestedAccount.Email,
                    PhotoId = requestedAccount.PhotoId,
                    Photo = requestedAccount.Photo != null ?
                        Mapper.Map<PhotoGetDetailResponse>(requestedAccount.Photo) : null,
                    GoogleAccounts = requestedAccount.GoogleAccounts != null ?
                        Mapper.Map<List<GoogleAccountGetDetailResponse>>(requestedAccount.GoogleAccounts) : null,
                    ConnectionId = connection.Id
                };
            }

            if (accounts.Contains(account) == false)
            {
                accounts.Add(account);
            }
        }

        return accounts;
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
