using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Messages;

public class ConversationAccountManager(IRepository<ConversationAccount> repository) 
    : PaymentDomainService<ConversationAccount>(repository);
