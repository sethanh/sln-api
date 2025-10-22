using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class ProductGetDetailRequest : IRequest<ProductGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ProductGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
