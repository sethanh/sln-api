using MediatR;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrGetAllHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrGetAllRequest, PaymentQrGetAllResponse>
{
    public Task<PaymentQrGetAllResponse> Handle(PaymentQrGetAllRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.GetAll(request);
    }
}
