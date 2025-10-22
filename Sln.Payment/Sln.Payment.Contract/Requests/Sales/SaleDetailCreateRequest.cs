using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDetailCreateRequest : IRequest<SaleDetailCreateResponse>
{
    public required string Name { get; set; }
}

public class SaleDetailCreateResponse
{
    public required string Name { get; set; }
}
