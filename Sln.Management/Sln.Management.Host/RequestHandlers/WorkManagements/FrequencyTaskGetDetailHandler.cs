using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class FrequencyTaskGetDetailHandler(FrequencyTaskService frequencyTaskService) : IRequestHandler<FrequencyTaskGetDetailRequest, FrequencyTaskGetDetailResponse>
{
    public Task<FrequencyTaskGetDetailResponse> Handle(FrequencyTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return frequencyTaskService.GetDetail(request);
    }
}
