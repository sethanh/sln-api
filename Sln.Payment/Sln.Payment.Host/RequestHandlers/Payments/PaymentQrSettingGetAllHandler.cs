using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrSettingGetAllHandler(Business.Services.Payments.PaymentQrSettingService paymentQrSettingService) : IRequestHandler<PaymentQrSettingGetAllRequest, PaymentQrSettingGetAllResponse>
{
    public Task<PaymentQrSettingGetAllResponse> Handle(PaymentQrSettingGetAllRequest request, CancellationToken cancellationToken)
    {
        return paymentQrSettingService.GetAll(request);
    }
}
