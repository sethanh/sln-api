using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrTransactionCreateHandler(Business.Services.Payments.PaymentQrTransactionService paymentQrTransactionService) : IRequestHandler<PaymentQrTransactionCreateRequest, PaymentQrTransactionCreateResponse>
{
    public Task<PaymentQrTransactionCreateResponse> Handle(PaymentQrTransactionCreateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrTransactionService.Create(request);
    }
}