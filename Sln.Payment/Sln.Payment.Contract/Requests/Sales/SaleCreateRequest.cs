using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleCreateRequest : IRequest<SaleCreateResponse>
{
    public required string Name { get; set; }
}

public class SaleCreateResponse
{
    public required string Name { get; set; }
}
