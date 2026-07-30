using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.ReportServices.Capturess;

public class PostService(IServiceProvider serviceProvider) : PaymentReportService(serviceProvider)
{
}
