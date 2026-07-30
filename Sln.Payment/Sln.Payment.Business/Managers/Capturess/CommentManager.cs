using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Capturess;

public class CommentManager(IRepository<Comment> repository) 
    : PaymentDomainService<Comment>(repository);
