using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Sales;

public class SaleDetailManager(IRepository<SaleDetail> repository) 
    : PaymentDomainService<SaleDetail>(repository);
