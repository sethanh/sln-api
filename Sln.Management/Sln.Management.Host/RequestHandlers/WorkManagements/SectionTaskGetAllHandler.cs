using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SectionTaskGetAllHandler(SectionTaskService sectionTaskService) : IRequestHandler<SectionTaskGetAllRequest, SectionTaskGetAllResponse>
{
    public Task<SectionTaskGetAllResponse> Handle(SectionTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return sectionTaskService.GetAll(request);
    }
}
