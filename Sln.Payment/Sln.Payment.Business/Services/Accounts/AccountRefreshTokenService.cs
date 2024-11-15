using Sln.Payment.Business.Managers.Accounts;

namespace Sln.Payment.Business.Services.Accounts;

public class AccountRefreshTokenService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private AccountRefreshTokenManager AccountRefreshTokenManager => GetService<AccountRefreshTokenManager>();





}
