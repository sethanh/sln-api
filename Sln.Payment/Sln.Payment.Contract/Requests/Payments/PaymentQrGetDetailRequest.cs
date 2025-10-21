using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrGetDetailRequest : IRequest<PaymentQrGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class PaymentQrGetDetailResponse
{
    public required Guid Id { get; set; }
    public string? BinCode { get; set; }
    public string? AccountNo { get; set; }
    public string? AccountName { get; set; }
    public string? Description { get; set; }
}
