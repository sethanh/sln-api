using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class PriorityTaskUpdateHandler(PriorityTaskService priorityTaskService) : IRequestHandler<PriorityTaskUpdateRequest, PriorityTaskUpdateResponse>
{
    public Task<PriorityTaskUpdateResponse> Handle(PriorityTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return priorityTaskService.Update(request);
    }
}