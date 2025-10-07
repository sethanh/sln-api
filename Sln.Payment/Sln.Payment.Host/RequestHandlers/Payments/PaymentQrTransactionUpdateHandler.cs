using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrTransactionUpdateHandler(Business.Services.Payments.PaymentQrTransactionService paymentQrTransactionService) : IRequestHandler<PaymentQrTransactionUpdateRequest, PaymentQrTransactionUpdateResponse>
{
    public Task<PaymentQrTransactionUpdateResponse> Handle(PaymentQrTransactionUpdateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrTransactionService.Update(request);
    }
}