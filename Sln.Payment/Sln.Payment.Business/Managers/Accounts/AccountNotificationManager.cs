using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Accounts;

public class AccountNotificationManager(IRepository<AccountNotification> repository)
    : PaymentDomainService<AccountNotification>(repository);
