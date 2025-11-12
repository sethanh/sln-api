using Sln.Shared.Data.Interfaces;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers.Payments;

public class PaymentQrSettingManager(IRepository<PaymentQrSetting> repository)
    : PaymentDomainService<PaymentQrSetting>(repository);
