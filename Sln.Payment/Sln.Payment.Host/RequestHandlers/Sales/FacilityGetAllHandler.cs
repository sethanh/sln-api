using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class FacilityGetAllHandler(FacilityService facilityService) : IRequestHandler<FacilityGetAllRequest, FacilityGetAllResponse>
{
    public Task<FacilityGetAllResponse> Handle(FacilityGetAllRequest request, CancellationToken cancellationToken)
    {
        return facilityService.GetAll(request);
    }
}
