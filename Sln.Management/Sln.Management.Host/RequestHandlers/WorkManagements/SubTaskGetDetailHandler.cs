using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;
namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class SubTaskGetDetailHandler(SubTaskService subTaskService) : IRequestHandler<SubTaskGetDetailRequest, SubTaskGetDetailResponse>
{
    public Task<SubTaskGetDetailResponse> Handle(SubTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return subTaskService.GetDetail(request);
    }
}
