using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrSettingUpdateRequest : IRequest<PaymentQrSettingUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}

public class PaymentQrSettingUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
