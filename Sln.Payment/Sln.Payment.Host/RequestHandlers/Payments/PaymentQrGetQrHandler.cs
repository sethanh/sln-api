using MediatR;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrGetQrHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrGetQrRequest, PaymentQrGetQrResponse>
{
    public Task<PaymentQrGetQrResponse> Handle(PaymentQrGetQrRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.GetQr(request);
    }
}
