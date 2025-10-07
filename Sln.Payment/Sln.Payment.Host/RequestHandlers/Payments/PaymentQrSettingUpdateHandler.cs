using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrSettingUpdateHandler(Business.Services.Payments.PaymentQrSettingService paymentQrSettingService) : IRequestHandler<PaymentQrSettingUpdateRequest, PaymentQrSettingUpdateResponse>
{
    public Task<PaymentQrSettingUpdateResponse> Handle(PaymentQrSettingUpdateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrSettingService.Update(request);
    }
}