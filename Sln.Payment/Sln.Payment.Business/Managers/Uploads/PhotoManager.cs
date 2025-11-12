using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Uploads;

public class PhotoManager(IRepository<Photo> repository)
    : PaymentDomainService<Photo>(repository);
