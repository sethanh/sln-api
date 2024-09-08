using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class TaskManagementGetAllHandler(TaskManagementService taskManagementService) : IRequestHandler<TaskManagementGetAllRequest, TaskManagementGetAllResponse>
{
    public Task<TaskManagementGetAllResponse> Handle(TaskManagementGetAllRequest request, CancellationToken cancellationToken)
    {
        return taskManagementService.GetAll(request);
    }
}
