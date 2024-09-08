using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class EpicTaskGetDetailHandler(EpicTaskService epicTaskService) : IRequestHandler<EpicTaskGetDetailRequest, EpicTaskGetDetailResponse>
{
    public Task<EpicTaskGetDetailResponse> Handle(EpicTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return epicTaskService.GetDetail(request);
    }
}
