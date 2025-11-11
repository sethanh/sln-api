using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Accounts;

public class AccountManager(IRepository<Account> repository)
    : PaymentDomainService<Account>(repository);
