using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrSettingUpdateRequest : IRequest<PaymentQrSettingUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class PaymentQrSettingUpdateResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
