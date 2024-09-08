using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class TaskManagementUpdateHandler(TaskManagementService taskManagementService) : IRequestHandler<TaskManagementUpdateRequest, TaskManagementUpdateResponse>
{
    public Task<TaskManagementUpdateResponse> Handle(TaskManagementUpdateRequest request, CancellationToken cancellationToken)
    {
        return taskManagementService.Update(request);
    }
}