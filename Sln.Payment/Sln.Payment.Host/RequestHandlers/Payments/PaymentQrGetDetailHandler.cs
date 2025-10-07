using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrGetDetailHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrGetDetailRequest, PaymentQrGetDetailResponse>
{
    public Task<PaymentQrGetDetailResponse> Handle(PaymentQrGetDetailRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.GetDetail(request);
    }
}
