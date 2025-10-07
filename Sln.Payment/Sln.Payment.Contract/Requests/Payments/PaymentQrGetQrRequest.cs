using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrGetQrRequest : IRequest<PaymentQrGetQrResponse>
{
    public required string AccountNo { get; set; }
    public required string BinCode { get; set; }
    public decimal? Amount { get; set; }
    public string? AccountName { get; set; }
    public string? Description { get; set; }
}

public class PaymentQrGetQrResponse
{
    public string? QrCode { get; set; }
}
