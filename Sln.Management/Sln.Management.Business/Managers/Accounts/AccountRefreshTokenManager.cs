using Sln.Shared.Data.Abstractions;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.Accounts;

public class AccountRefreshTokenManager(IRepository<AccountRefreshToken> repository) 
    : ManagementDomainService<AccountRefreshToken>(repository);
