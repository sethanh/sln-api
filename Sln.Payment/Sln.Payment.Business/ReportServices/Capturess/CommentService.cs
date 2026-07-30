using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.ReportServices.Capturess;

public class CommentService(IServiceProvider serviceProvider) : PaymentReportService(serviceProvider)
{
}
