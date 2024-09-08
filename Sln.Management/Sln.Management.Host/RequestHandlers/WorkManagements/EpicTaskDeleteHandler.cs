using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class EpicTaskDeleteHandler(EpicTaskService epicTaskService) : IRequestHandler<EpicTaskDeleteRequest>
{
    public Task Handle(EpicTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return epicTaskService.Delete(request);
    }
}
