using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDetailUpdateRequest : IRequest<SaleDetailUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class SaleDetailUpdateResponse :SaleDetailGetDetailResponse
{
}
