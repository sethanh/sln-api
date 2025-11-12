using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.GoogleAccounts;

public class GoogleAccountManager(IRepository<GoogleAccount> repository)
    : PaymentDomainService<GoogleAccount>(repository);
