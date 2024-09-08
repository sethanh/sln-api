using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class ImportanceTaskGetDetailHandler(ImportanceTaskService importanceTaskService) : IRequestHandler<ImportanceTaskGetDetailRequest, ImportanceTaskGetDetailResponse>
{
    public Task<ImportanceTaskGetDetailResponse> Handle(ImportanceTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return importanceTaskService.GetDetail(request);
    }
}
