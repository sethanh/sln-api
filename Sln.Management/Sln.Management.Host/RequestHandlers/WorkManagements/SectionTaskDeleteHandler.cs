using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SectionTaskDeleteHandler(SectionTaskService sectionTaskService) : IRequestHandler<SectionTaskDeleteRequest>
{
    public Task Handle(SectionTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return sectionTaskService.Delete(request);
    }
}
