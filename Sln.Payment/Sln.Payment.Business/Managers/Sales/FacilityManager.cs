using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Sales;

public class FacilityManager(IRepository<Facility> repository)
    : PaymentDomainService<Facility>(repository);
