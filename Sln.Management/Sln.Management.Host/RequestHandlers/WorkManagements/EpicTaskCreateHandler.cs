using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class EpicTaskCreateHandler(EpicTaskService epicTaskService) : IRequestHandler<EpicTaskCreateRequest, EpicTaskCreateResponse>
{
    public Task<EpicTaskCreateResponse> Handle(EpicTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return epicTaskService.Create(request);
    }
}