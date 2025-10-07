using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrUpdateHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrUpdateRequest, PaymentQrUpdateResponse>
{
    public Task<PaymentQrUpdateResponse> Handle(PaymentQrUpdateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.Update(request);
    }
}