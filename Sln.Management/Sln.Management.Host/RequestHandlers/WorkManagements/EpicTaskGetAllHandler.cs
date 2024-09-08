using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class EpicTaskGetAllHandler(EpicTaskService epicTaskService) : IRequestHandler<EpicTaskGetAllRequest, EpicTaskGetAllResponse>
{
    public Task<EpicTaskGetAllResponse> Handle(EpicTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return epicTaskService.GetAll(request);
    }
}
