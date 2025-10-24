using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Messages;

public class ConversationManager(IRepository<Conversation> repository) 
    : PaymentDomainService<Conversation>(repository);
