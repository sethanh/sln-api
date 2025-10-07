using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrTransactionGetAllRequest : PaginationRequest, IRequest<PaymentQrTransactionGetAllResponse>
{
}

public class PaymentQrTransactionGetAllResponse : PaginationResponse<PaymentQrTransactionGetAllResponseItem>
{
}

public class PaymentQrTransactionGetAllResponseItem
{
    public required long Id { get; set; }
    public required string Name { get; set; }
}