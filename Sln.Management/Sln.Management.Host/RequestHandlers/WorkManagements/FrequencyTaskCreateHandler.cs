using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class FrequencyTaskCreateHandler(FrequencyTaskService frequencyTaskService) : IRequestHandler<FrequencyTaskCreateRequest, FrequencyTaskCreateResponse>
{
    public Task<FrequencyTaskCreateResponse> Handle(FrequencyTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return frequencyTaskService.Create(request);
    }
}