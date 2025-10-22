using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class FacilityGetDetailRequest : IRequest<FacilityGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class FacilityGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
