using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class RangeTaskGetDetailHandler(RangeTaskService rangeTaskService) : IRequestHandler<RangeTaskGetDetailRequest, RangeTaskGetDetailResponse>
{
    public Task<RangeTaskGetDetailResponse> Handle(RangeTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return rangeTaskService.GetDetail(request);
    }
}
