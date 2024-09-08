using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class PriorityTaskGetDetailHandler(PriorityTaskService priorityTaskService) : IRequestHandler<PriorityTaskGetDetailRequest, PriorityTaskGetDetailResponse>
{
    public Task<PriorityTaskGetDetailResponse> Handle(PriorityTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return priorityTaskService.GetDetail(request);
    }
}
