using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class TaskManagementDeleteHandler(TaskManagementService taskManagementService) : IRequestHandler<TaskManagementDeleteRequest>
{
    public Task Handle(TaskManagementDeleteRequest request, CancellationToken cancellationToken)
    {
        return taskManagementService.Delete(request);
    }
}
