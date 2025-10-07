using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrSettingCreateHandler(Business.Services.Payments.PaymentQrSettingService paymentQrSettingService) : IRequestHandler<PaymentQrSettingCreateRequest, PaymentQrSettingCreateResponse>
{
    public Task<PaymentQrSettingCreateResponse> Handle(PaymentQrSettingCreateRequest request, CancellationToken cancellationToken)
    {
        return paymentQrSettingService.Create(request);
    }
}