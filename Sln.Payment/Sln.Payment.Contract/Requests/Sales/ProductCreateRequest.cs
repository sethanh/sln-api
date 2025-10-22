using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductCreateRequest : IRequest<ProductCreateResponse>
{
    public required string Name { get; set; }
}

public class ProductCreateResponse
{
    public required string Name { get; set; }
}
