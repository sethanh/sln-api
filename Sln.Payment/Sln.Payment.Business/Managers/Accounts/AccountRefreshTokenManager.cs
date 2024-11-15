using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Accounts;

public class AccountRefreshTokenManager(IRepository<AccountRefreshToken> repository)
    : PaymentDomainService<AccountRefreshToken>(repository)
{
    public AccountRefreshToken? AddOrgAccountRefreshToken(Account account, string refreshToken)
    {
        var newRefreshToken = new AccountRefreshToken
        {
            AccountId = account.Id,
            RefreshToken = refreshToken,
            AccountName = $"{account.Id}_{account.Email}",
            IsActive = true,
            ExpiredTime = DateTime.Now.AddDays(2)
        };

        Add(newRefreshToken);
        return newRefreshToken;
    }
}
