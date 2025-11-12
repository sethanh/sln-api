using Sln.Payment.Contract.Errors.Accounts;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Accounts;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Sln.Payment.Business.Helpers.Accounts;
using Sln.Shared.Business.Services;
using System.Text.Json;
using Sln.Payment.Business.Managers.GoogleAccounts;
using Mapster;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Business.Services.Accounts;

public class AccountService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private const string UserInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo";
    private AccountManager AccountManager => GetService<AccountManager>();
    private AccountRefreshTokenManager AccountRefreshTokenManager => GetService<AccountRefreshTokenManager>();
    private GoogleTokenValidatorService GoogleTokenValidatorService => GetService<GoogleTokenValidatorService>();
    private GoogleAccountManager GoogleAccountManager => GetService<GoogleAccountManager>();

    public async Task<AccountLoginResponse> GoogleVerifyLogin(AccountGoogleVerifyRequest request)
    {
        var payload = await GoogleTokenValidatorService.ValidateTokenAsync(request.IdToken) ?? throw new HttpUnauthorized("Invalid Google token");
        var account = AccountManager.GetAll()
            .FirstOrDefault(c => c.Email == payload.Email);

        if (account == null)
        {
            account = new Account
            {
                Email = payload.Email,
                Name = payload.Name,
                Password = "ABCDEF"
            };

            AccountManager.Add(account);
        }

        var tokenValue = JwtHelpers.GenerateJWTTokens(account);

        AccountRefreshTokenManager.AddOrgAccountRefreshToken(account, tokenValue.RefreshToken);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountLoginResponse>(tokenValue);
    }

    public async Task<AccountLoginResponse> GoogleLogin(AccountGoogleLoginRequest request)
    {
        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", request.AccessToken);

        var response = await httpClient.GetAsync(UserInfoEndpoint);


        if (!response.IsSuccessStatusCode)
        {
            throw new HttpUnauthorized("Invalid Google token");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var googleAccount = JsonSerializer.Deserialize<AccountGoogleInfo>(jsonResponse);

        if (googleAccount?.email == null)
        {
            throw new HttpUnauthorized("Invalid Google token");
        }

        var account = AccountManager.GetAll()
            .FirstOrDefault(c => c.Email == googleAccount.email);

        var oldGoogleAccount = GoogleAccountManager.GetAll()
            .FirstOrDefault(c => c.Email == googleAccount.email);

        if (account == null)
        {
            account = new Account
            {
                Email = googleAccount.email,
                Name = googleAccount?.name ?? "Unknown",
                Password = googleAccount?.sub ?? Guid.NewGuid().ToString()
            };

            AccountManager.Add(account);
            await UnitOfWork.SaveChangesAsync();
        }

        if (oldGoogleAccount == null)
        {
            var newGoogleAccount = new GoogleAccount
            {
                Email = googleAccount?.email,
                Name = googleAccount?.name,
                Picture = googleAccount?.picture,
                Sub = googleAccount?.sub,
                AccountId = account.Id
            };

            GoogleAccountManager.Add(newGoogleAccount);
            await UnitOfWork.SaveChangesAsync();
        }

        var tokenValue = JwtHelpers.GenerateJWTTokens(account);

        AccountRefreshTokenManager.AddOrgAccountRefreshToken(account, tokenValue.RefreshToken);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountLoginResponse>(tokenValue);
    }


    public async Task<AccountLoginResponse> Login(AccountLoginRequest request)
    {
        var account = AccountManager.GetAll()
            .FirstOrDefault(c => c.Email == request.Email && c.Password == request.Password)
            ?? throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);

        var tokenValue = JwtHelpers.GenerateJWTTokens(account);

        AccountRefreshTokenManager.AddOrgAccountRefreshToken(account, tokenValue.RefreshToken);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountLoginResponse>(tokenValue);
    }

    public Task<AccountGetAllResponse> GetAll(AccountGetAllRequest request)
    {
        var Account = AccountManager.GetAll().Where(c => c.Email == request.Email);

        var paginationResponse = PaginationResponse<Account>.Create(
            Account,
            request
        );

        return Task.FromResult(Mapper.Map<AccountGetAllResponse>(paginationResponse));
    }

    public Task<AccountGetDetailResponse> GetCurrentAccount(CurrentAccountGetDetailRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == CurrentAccount.Id) ?? throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);

        var googleAccount = GoogleAccountManager.FirstOrDefault(c => c.AccountId == CurrentAccount.Id);

        var result = Mapper.Map<AccountGetDetailResponse>(account);
        result.GoogleAccount = googleAccount != null ? new GoogleAccountGetDetailResponse
        {
            Id = googleAccount!.Id,
            Email = googleAccount.Email,
            Picture = googleAccount.Picture

        } : null;

        return Task.FromResult(result);
    }

    public Task<AccountResponse> GetDetail(AccountGetDetailRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (account == null)
        {
            throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<AccountResponse>(account));
    }

    public async Task<AccountCreateResponse> Create(AccountCreateRequest request)
    {
        var account = Mapper.Map<Account>(request);

        AccountManager.Add(account);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountCreateResponse>(account);
    }

    public async Task<AccountUpdateResponse> Update(AccountUpdateRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id) ?? throw new HttpBadRequest(AccountErrors.ACCOUNT_NOT_FOUND);
        if (request.Password == "********")
        {
            request.Password = account.Password;
        }

        var updatedAccount = request.Adapt(account);
        AccountManager.Update(updatedAccount);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<AccountUpdateResponse>(updatedAccount);
    }

    public async Task Delete(AccountDeleteRequest request)
    {
        var account = AccountManager.FirstOrDefault(o => o.Id == request.Id);

        if (account == null)
        {
            throw new HttpNotFound(AccountErrors.ACCOUNT_NOT_FOUND);
        }

        AccountManager.Delete(account);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
