using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Capturess;

public class PostManager(IRepository<Post> repository) 
    : PaymentDomainService<Post>(repository);
