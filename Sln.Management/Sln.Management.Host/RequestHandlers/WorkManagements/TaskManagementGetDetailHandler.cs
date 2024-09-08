using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class TaskManagementGetDetailHandler(TaskManagementService taskManagementService) : IRequestHandler<TaskManagementGetDetailRequest, TaskManagementGetDetailResponse>
{
    public Task<TaskManagementGetDetailResponse> Handle(TaskManagementGetDetailRequest request, CancellationToken cancellationToken)
    {
        return taskManagementService.GetDetail(request);
    }
}
