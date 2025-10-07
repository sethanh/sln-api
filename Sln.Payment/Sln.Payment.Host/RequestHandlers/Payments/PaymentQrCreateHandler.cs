using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrCreateHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrCreateRequest, PaymentQrCreateResponse>
{
    public Task<PaymentQrCreateResponse> Handle(PaymentQrCreateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.Create(request);
    }
}