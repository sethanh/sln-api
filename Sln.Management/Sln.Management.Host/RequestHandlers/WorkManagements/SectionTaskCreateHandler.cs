using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SectionTaskCreateHandler(SectionTaskService sectionTaskService) : IRequestHandler<SectionTaskCreateRequest, SectionTaskCreateResponse>
{
    public Task<SectionTaskCreateResponse> Handle(SectionTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return sectionTaskService.Create(request);
    }
}