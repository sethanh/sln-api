using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrUpdateRequest : IRequest<PaymentQrUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class PaymentQrUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
