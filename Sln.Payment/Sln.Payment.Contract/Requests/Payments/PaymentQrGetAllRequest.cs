using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrGetAllRequest : PaginationRequest, IRequest<PaymentQrGetAllResponse>
{
}

public class PaymentQrGetAllResponse : PaginationResponse<PaymentQrGetAllResponseItem>
{
}

public class PaymentQrGetAllResponseItem : PaymentQrGetDetailResponse
{
}