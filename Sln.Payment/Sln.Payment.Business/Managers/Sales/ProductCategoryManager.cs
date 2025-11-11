using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Sales;

public class ProductCategoryManager(IRepository<ProductCategory> repository)
    : PaymentDomainService<ProductCategory>(repository);
