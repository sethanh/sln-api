using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Sales;

public class ProductManager(IRepository<Product> repository)
    : PaymentDomainService<Product>(repository);
