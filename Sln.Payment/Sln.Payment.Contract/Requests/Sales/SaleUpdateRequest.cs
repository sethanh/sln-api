using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleUpdateRequest : IRequest<SaleUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class SaleUpdateResponse : SaleGetDetailResponse
{
}
