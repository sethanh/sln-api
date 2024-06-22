using Sln.Shared.Data.Abstractions;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.Accounts;

public class AccountManager(IRepository<Account> repository) 
    : ManagementDomainService<Account>(repository);
