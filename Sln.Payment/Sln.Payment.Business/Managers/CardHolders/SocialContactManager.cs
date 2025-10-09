using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.CardHolders;

public class SocialContactManager(IRepository<SocialContact> repository) 
    : PaymentDomainService<SocialContact>(repository);
