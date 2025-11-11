using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrCreateRequest : IRequest<PaymentQrCreateResponse>
{
    public string? BinCode { get; set; }
    public string? AccountNo { get; set; }
    public string? AccountName { get; set; }
    public string? Description { get; set; }
}

public class PaymentQrCreateResponse : PaymentQrGetDetailResponse
{
}
