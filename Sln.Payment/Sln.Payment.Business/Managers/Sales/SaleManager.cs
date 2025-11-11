using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Sales;

public class SaleManager(IRepository<Sale> repository)
    : PaymentDomainService<Sale>(repository);
