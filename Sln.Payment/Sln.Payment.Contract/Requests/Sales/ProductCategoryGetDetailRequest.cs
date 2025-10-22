using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductCategoryGetDetailRequest : IRequest<ProductCategoryGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ProductCategoryGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
