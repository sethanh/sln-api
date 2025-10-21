using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrSettingGetDetailRequest : IRequest<PaymentQrSettingGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class PaymentQrSettingGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
