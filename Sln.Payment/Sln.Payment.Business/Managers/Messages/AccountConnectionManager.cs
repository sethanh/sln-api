using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Messages;

public class AccountConnectionManager(IRepository<AccountConnection> repository) 
    : PaymentDomainService<AccountConnection>(repository);
