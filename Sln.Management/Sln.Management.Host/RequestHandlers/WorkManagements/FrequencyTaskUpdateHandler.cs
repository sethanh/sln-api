using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class FrequencyTaskUpdateHandler(FrequencyTaskService frequencyTaskService) : IRequestHandler<FrequencyTaskUpdateRequest, FrequencyTaskUpdateResponse>
{
    public Task<FrequencyTaskUpdateResponse> Handle(FrequencyTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return frequencyTaskService.Update(request);
    }
}