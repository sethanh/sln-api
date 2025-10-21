using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrSettingGetAllRequest : PaginationRequest, IRequest<PaymentQrSettingGetAllResponse>
{
}

public class PaymentQrSettingGetAllResponse : PaginationResponse<PaymentQrSettingGetAllResponseItem>
{
}

public class PaymentQrSettingGetAllResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}