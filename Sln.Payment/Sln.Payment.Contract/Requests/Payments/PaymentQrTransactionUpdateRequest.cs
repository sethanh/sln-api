using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrTransactionUpdateRequest : IRequest<PaymentQrTransactionUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class PaymentQrTransactionUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
