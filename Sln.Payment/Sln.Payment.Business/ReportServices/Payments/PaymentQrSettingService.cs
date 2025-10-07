using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.ReportServices.Payments;

public class PaymentQrSettingService(IServiceProvider serviceProvider) : PaymentReportService(serviceProvider)
{
}
