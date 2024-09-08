using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class ImportanceTaskDeleteHandler(ImportanceTaskService importanceTaskService) : IRequestHandler<ImportanceTaskDeleteRequest>
{
    public Task Handle(ImportanceTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return importanceTaskService.Delete(request);
    }
}
