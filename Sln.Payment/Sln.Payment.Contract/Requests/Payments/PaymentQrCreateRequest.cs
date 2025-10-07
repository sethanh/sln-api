using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrCreateRequest : IRequest<PaymentQrCreateResponse>
{
    public required string Name { get; set; }
}

public class PaymentQrCreateResponse
{
    public required string Name { get; set; }
}
