using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrTransactionGetDetailHandler(Business.Services.Payments.PaymentQrTransactionService paymentQrTransactionService) : IRequestHandler<PaymentQrTransactionGetDetailRequest, PaymentQrTransactionGetDetailResponse>
{
    public Task<PaymentQrTransactionGetDetailResponse> Handle(PaymentQrTransactionGetDetailRequest request, CancellationToken cancellationToken)
    {
        return paymentQrTransactionService.GetDetail(request);
    }
}
