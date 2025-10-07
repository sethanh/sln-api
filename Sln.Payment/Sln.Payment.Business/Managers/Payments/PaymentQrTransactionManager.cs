using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Payments;

public class PaymentQrTransactionManager(IRepository<PaymentQrTransaction> repository) 
    : PaymentDomainService<PaymentQrTransaction>(repository);
