using Sln.Management.Business.Managers.Accounts;

namespace Sln.Management.Business.Services.Accounts;

public class AccountRefreshTokenService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private AccountRefreshTokenManager AccountRefreshTokenManager => GetService<AccountRefreshTokenManager>();





}
