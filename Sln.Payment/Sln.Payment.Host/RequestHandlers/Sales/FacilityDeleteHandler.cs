using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class FacilityDeleteHandler(FacilityService facilityService) : IRequestHandler<FacilityDeleteRequest>
{
    public Task Handle(FacilityDeleteRequest request, CancellationToken cancellationToken)
    {
        return facilityService.Delete(request);
    }
}
