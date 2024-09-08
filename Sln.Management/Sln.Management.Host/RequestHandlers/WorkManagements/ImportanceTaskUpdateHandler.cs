using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class ImportanceTaskUpdateHandler(ImportanceTaskService importanceTaskService) : IRequestHandler<ImportanceTaskUpdateRequest, ImportanceTaskUpdateResponse>
{
    public Task<ImportanceTaskUpdateResponse> Handle(ImportanceTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return importanceTaskService.Update(request);
    }
}