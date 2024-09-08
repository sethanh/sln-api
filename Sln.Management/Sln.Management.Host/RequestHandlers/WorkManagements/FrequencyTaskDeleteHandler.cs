using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class FrequencyTaskDeleteHandler(FrequencyTaskService frequencyTaskService) : IRequestHandler<FrequencyTaskDeleteRequest>
{
    public Task Handle(FrequencyTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return frequencyTaskService.Delete(request);
    }
}
