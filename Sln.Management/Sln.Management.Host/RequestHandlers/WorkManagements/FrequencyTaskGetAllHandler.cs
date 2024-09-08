using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class FrequencyTaskGetAllHandler(FrequencyTaskService frequencyTaskService) : IRequestHandler<FrequencyTaskGetAllRequest, FrequencyTaskGetAllResponse>
{
    public Task<FrequencyTaskGetAllResponse> Handle(FrequencyTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return frequencyTaskService.GetAll(request);
    }
}
