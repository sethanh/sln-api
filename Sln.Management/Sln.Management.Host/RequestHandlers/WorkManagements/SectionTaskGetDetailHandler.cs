using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SectionTaskGetDetailHandler(SectionTaskService sectionTaskService) : IRequestHandler<SectionTaskGetDetailRequest, SectionTaskGetDetailResponse>
{
    public Task<SectionTaskGetDetailResponse> Handle(SectionTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return sectionTaskService.GetDetail(request);
    }
}
