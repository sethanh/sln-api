using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class FacilityUpdateHandler(FacilityService facilityService) : IRequestHandler<FacilityUpdateRequest, FacilityUpdateResponse>
{
    public Task<FacilityUpdateResponse> Handle(FacilityUpdateRequest request, CancellationToken cancellationToken)
    {
        return facilityService.Update(request);
    }
}