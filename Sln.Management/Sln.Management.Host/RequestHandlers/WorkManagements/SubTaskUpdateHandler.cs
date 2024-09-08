using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SubTaskUpdateHandler(SubTaskService subTaskService) : IRequestHandler<SubTaskUpdateRequest, SubTaskUpdateResponse>
{
    public Task<SubTaskUpdateResponse> Handle(SubTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return subTaskService.Update(request);
    }
}