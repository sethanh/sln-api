using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class FacilityCreateHandler(FacilityService facilityService) : IRequestHandler<FacilityCreateRequest, FacilityCreateResponse>
{
    public Task<FacilityCreateResponse> Handle(FacilityCreateRequest request, CancellationToken cancellationToken)
    {
        return facilityService.Create(request);
    }
}