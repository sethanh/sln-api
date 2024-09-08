using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class PriorityTaskCreateHandler(PriorityTaskService priorityTaskService) : IRequestHandler<PriorityTaskCreateRequest, PriorityTaskCreateResponse>
{
    public Task<PriorityTaskCreateResponse> Handle(PriorityTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return priorityTaskService.Create(request);
    }
}