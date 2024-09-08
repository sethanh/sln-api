using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class RangeTaskCreateHandler(RangeTaskService rangeTaskService) : IRequestHandler<RangeTaskCreateRequest, RangeTaskCreateResponse>
{
    public Task<RangeTaskCreateResponse> Handle(RangeTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return rangeTaskService.Create(request);
    }
}