using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class FacilityCreateRequest : IRequest<FacilityCreateResponse>
{
    public required string Name { get; set; }
}

public class FacilityCreateResponse
{
    public required string Name { get; set; }
}
