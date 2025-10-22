using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleGetAllRequest : PaginationRequest, IRequest<SaleGetAllResponse>
{
}

public class SaleGetAllResponse : PaginationResponse<SaleGetAllResponseItem>
{
}

public class SaleGetAllResponseItem : SaleGetDetailResponse
{
}