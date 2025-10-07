using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrTransactionCreateRequest : IRequest<PaymentQrTransactionCreateResponse>
{
    public required string Name { get; set; }
}

public class PaymentQrTransactionCreateResponse
{
    public required string Name { get; set; }
}
