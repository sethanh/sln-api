using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrTransactionGetDetailRequest : IRequest<PaymentQrTransactionGetDetailResponse>
{
    public required long Id { get; set; }
}

public class PaymentQrTransactionGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
