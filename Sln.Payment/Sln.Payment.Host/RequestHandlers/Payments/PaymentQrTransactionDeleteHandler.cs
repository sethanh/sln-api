using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrTransactionDeleteHandler(Business.Services.Payments.PaymentQrTransactionService paymentQrTransactionService) : IRequestHandler<PaymentQrTransactionDeleteRequest>
{
    public Task Handle(PaymentQrTransactionDeleteRequest request, CancellationToken cancellationToken)
    {
        return paymentQrTransactionService.Delete(request);
    }
}
