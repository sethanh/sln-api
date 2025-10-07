using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrSettingGetDetailHandler(Business.Services.Payments.PaymentQrSettingService paymentQrSettingService) : IRequestHandler<PaymentQrSettingGetDetailRequest, PaymentQrSettingGetDetailResponse>
{
    public Task<PaymentQrSettingGetDetailResponse> Handle(PaymentQrSettingGetDetailRequest request, CancellationToken cancellationToken)
    {
        return paymentQrSettingService.GetDetail(request);
    }
}
