using MediatR;
using Sln.Payment.Contract.Requests.Payments;
using Sln.Payment.Business.Services.Payments;
using Sln.Payment.Business.ReportServices.Payments;

namespace Sln.Payment.Host.RequestHandlers.Payments;

public class PaymentQrTransactionGetAllHandler(Business.Services.Payments.PaymentQrTransactionService paymentQrTransactionService) : IRequestHandler<PaymentQrTransactionGetAllRequest, PaymentQrTransactionGetAllResponse>
{
    public Task<PaymentQrTransactionGetAllResponse> Handle(PaymentQrTransactionGetAllRequest request, CancellationToken cancellationToken)
    {
        return paymentQrTransactionService.GetAll(request);
    }
}
