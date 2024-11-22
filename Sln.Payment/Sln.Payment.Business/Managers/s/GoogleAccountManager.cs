using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.s;

public class GoogleAccountManager(IRepository<GoogleAccount> repository) 
    : PaymentDomainService<GoogleAccount>(repository);
