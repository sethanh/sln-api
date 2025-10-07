using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrGetDetailRequest : IRequest<PaymentQrGetDetailResponse>
{
    public required long Id { get; set; }
}

public class PaymentQrGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}
