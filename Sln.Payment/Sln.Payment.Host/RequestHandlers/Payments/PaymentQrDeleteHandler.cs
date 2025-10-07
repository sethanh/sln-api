using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrDeleteHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrDeleteRequest>
{
    public Task Handle(PaymentQrDeleteRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.Delete(request);
    }
}
