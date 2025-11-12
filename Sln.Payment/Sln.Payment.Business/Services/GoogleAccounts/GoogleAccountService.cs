using Sln.Payment.Business.Managers.GoogleAccounts;

namespace Sln.Payment.Business.Services.s;

public class GoogleAccountService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private GoogleAccountManager GoogleAccountManager => GetService<GoogleAccountManager>();

}
