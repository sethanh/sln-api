using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class PriorityTaskDeleteHandler(PriorityTaskService priorityTaskService) : IRequestHandler<PriorityTaskDeleteRequest>
{
    public Task Handle(PriorityTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return priorityTaskService.Delete(request);
    }
}
