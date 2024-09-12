using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SectionTaskUpdateHandler(SectionTaskService sectionTaskService) : IRequestHandler<SectionTaskUpdateRequest, SectionTaskUpdateResponse>
{
    public Task<SectionTaskUpdateResponse> Handle(SectionTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return sectionTaskService.Update(request);
    }
}