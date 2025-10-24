using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Messages;

public class ChatMessageManager(IRepository<ChatMessage> repository) 
    : PaymentDomainService<ChatMessage>(repository);
