using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class PriorityTaskGetAllHandler(PriorityTaskService priorityTaskService) : IRequestHandler<PriorityTaskGetAllRequest, PriorityTaskGetAllResponse>
{
    public Task<PriorityTaskGetAllResponse> Handle(PriorityTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return priorityTaskService.GetAll(request);
    }
}
