using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDetailGetAllRequest : PaginationRequest, IRequest<SaleDetailGetAllResponse>
{
}

public class SaleDetailGetAllResponse : PaginationResponse<SaleDetailGetAllResponseItem>
{
}

public class SaleDetailGetAllResponseItem : SaleDetailGetDetailResponse
{
}