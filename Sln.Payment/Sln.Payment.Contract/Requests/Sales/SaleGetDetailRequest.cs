using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleGetDetailRequest : IRequest<SaleGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class SaleGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
