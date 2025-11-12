using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Payments;

public class PaymentQrManager(IRepository<PaymentQr> repository)
    : PaymentDomainService<PaymentQr>(repository);
