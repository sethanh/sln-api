using MediatR;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrGetAllBankHandler(Business.Services.Payments.PaymentQrService paymentQrService) : IRequestHandler<PaymentQrGetAllBankRequest, PaymentQrGetAllBankResponse>
{
    public Task<PaymentQrGetAllBankResponse> Handle(PaymentQrGetAllBankRequest request, CancellationToken cancellationToken)
    {
        return paymentQrService.GetAllBank(request);
    }
}
