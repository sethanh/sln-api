using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.CardHolders;

public class ContactManager(IRepository<Contact> repository) 
    : PaymentDomainService<Contact>(repository);
