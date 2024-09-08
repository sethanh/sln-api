using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SubTaskDeleteHandler(SubTaskService subTaskService) : IRequestHandler<SubTaskDeleteRequest>
{
    public Task Handle(SubTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return subTaskService.Delete(request);
    }
}
