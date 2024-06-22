using Sln.Management.Contract.Errors.Accounts;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.Accounts;
using Sln.Shared.Business.Abstractions;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.Accounts;

public class AccountService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private AccountManager AccountManager => GetService<AccountManager>();

    public Task<AccountGetAllResponse> GetAll(AccountGetAllRequest request)
    {
        var Account = AccountManager.GetAll();

        var paginationResponse = PaginationResponse<Account>.Create(
            Account,
            request
        );

        return Task.FromResult(Mapper.Map<AccountGetAllResponse>(paginationResponse));
    }

    public Task<AccountGetDetailResponse> GetDetail(AccountGetDetailRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (account == null)
        {
            throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<AccountGetDetailResponse>(account));
    }

    public Task<AccountCreateResponse> Create(AccountCreateRequest request)
    {
        var account = Mapper.Map<Account>(request);

        AccountManager.Add(account);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<AccountCreateResponse>(account));
    }

    public Task<AccountUpdateResponse> Update(AccountUpdateRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id);

        if(account == null)
        {
            throw new HttpBadRequest(AccountErrors.ACCOUNT_NOT_FOUND);
        }

        // TODO: Update account properties

        var updatedAccount = AccountManager.Update(account);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<AccountUpdateResponse>(updatedAccount));
    }

    public Task Delete(AccountDeleteRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (account == null)
        {
            throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);
        }

        AccountManager.Delete(account);

        UnitOfWork.SaveChanges();
        return Task.FromResult("");
    }
}
