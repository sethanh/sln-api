using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDetailGetDetailRequest : IRequest<SaleDetailGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class SaleDetailGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
