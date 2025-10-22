using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductGetAllRequest : PaginationRequest, IRequest<ProductGetAllResponse>
{
}

public class ProductGetAllResponse : PaginationResponse<ProductGetAllResponseItem>
{
}

public class ProductGetAllResponseItem : ProductGetDetailResponse
{
}