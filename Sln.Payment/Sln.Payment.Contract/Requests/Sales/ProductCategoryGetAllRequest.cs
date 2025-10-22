using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductCategoryGetAllRequest : PaginationRequest, IRequest<ProductCategoryGetAllResponse>
{
}

public class ProductCategoryGetAllResponse : PaginationResponse<ProductCategoryGetAllResponseItem>
{
}

public class ProductCategoryGetAllResponseItem : ProductCategoryGetDetailResponse
{
}