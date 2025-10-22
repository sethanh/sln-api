using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class FacilityGetDetailHandler(FacilityService facilityService) : IRequestHandler<FacilityGetDetailRequest, FacilityGetDetailResponse>
{
    public Task<FacilityGetDetailResponse> Handle(FacilityGetDetailRequest request, CancellationToken cancellationToken)
    {
        return facilityService.GetDetail(request);
    }
}
