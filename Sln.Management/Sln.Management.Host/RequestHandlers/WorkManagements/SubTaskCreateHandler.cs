using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SubTaskCreateHandler(SubTaskService subTaskService) : IRequestHandler<SubTaskCreateRequest, SubTaskCreateResponse>
{
    public Task<SubTaskCreateResponse> Handle(SubTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return subTaskService.Create(request);
    }
}