using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class TaskManagementCreateHandler(TaskManagementService taskManagementService) : IRequestHandler<TaskManagementCreateRequest, TaskManagementCreateResponse>
{
    public Task<TaskManagementCreateResponse> Handle(TaskManagementCreateRequest request, CancellationToken cancellationToken)
    {
        return taskManagementService.Create(request);
    }
}