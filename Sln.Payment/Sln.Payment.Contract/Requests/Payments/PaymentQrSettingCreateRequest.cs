using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrSettingCreateRequest : IRequest<PaymentQrSettingCreateResponse>
{
    public required string Name { get; set; }
}

public class PaymentQrSettingCreateResponse
{
    public required string Name { get; set; }
}
