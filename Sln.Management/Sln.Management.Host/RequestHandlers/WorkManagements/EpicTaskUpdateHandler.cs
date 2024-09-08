using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class EpicTaskUpdateHandler(EpicTaskService epicTaskService) : IRequestHandler<EpicTaskUpdateRequest, EpicTaskUpdateResponse>
{
    public Task<EpicTaskUpdateResponse> Handle(EpicTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return epicTaskService.Update(request);
    }
}