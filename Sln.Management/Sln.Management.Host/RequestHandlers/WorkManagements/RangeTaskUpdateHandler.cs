using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class RangeTaskUpdateHandler(RangeTaskService rangeTaskService) : IRequestHandler<RangeTaskUpdateRequest, RangeTaskUpdateResponse>
{
    public Task<RangeTaskUpdateResponse> Handle(RangeTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return rangeTaskService.Update(request);
    }
}