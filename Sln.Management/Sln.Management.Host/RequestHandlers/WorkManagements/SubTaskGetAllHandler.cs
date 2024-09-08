using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SubTaskGetAllHandler(SubTaskService subTaskService) : IRequestHandler<SubTaskGetAllRequest, SubTaskGetAllResponse>
{
    public Task<SubTaskGetAllResponse> Handle(SubTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return subTaskService.GetAll(request);
    }
}
