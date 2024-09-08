using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class RangeTaskGetAllHandler(RangeTaskService rangeTaskService) : IRequestHandler<RangeTaskGetAllRequest, RangeTaskGetAllResponse>
{
    public Task<RangeTaskGetAllResponse> Handle(RangeTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return rangeTaskService.GetAll(request);
    }
}
