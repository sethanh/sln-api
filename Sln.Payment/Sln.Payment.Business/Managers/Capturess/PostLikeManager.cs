using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Capturess;

public class PostLikeManager(IRepository<PostLike> repository) 
    : PaymentDomainService<PostLike>(repository);
