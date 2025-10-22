using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductCategoryCreateRequest : IRequest<ProductCategoryCreateResponse>
{
    public required string Name { get; set; }
}

public class ProductCategoryCreateResponse
{
    public required string Name { get; set; }
}
