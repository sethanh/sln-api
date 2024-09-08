using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class ImportanceTaskGetAllHandler(ImportanceTaskService importanceTaskService) : IRequestHandler<ImportanceTaskGetAllRequest, ImportanceTaskGetAllResponse>
{
    public Task<ImportanceTaskGetAllResponse> Handle(ImportanceTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return importanceTaskService.GetAll(request);
    }
}
