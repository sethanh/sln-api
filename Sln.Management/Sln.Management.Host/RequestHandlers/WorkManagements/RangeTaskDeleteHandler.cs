using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class RangeTaskDeleteHandler(RangeTaskService rangeTaskService) : IRequestHandler<RangeTaskDeleteRequest>
{
    public Task Handle(RangeTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return rangeTaskService.Delete(request);
    }
}
