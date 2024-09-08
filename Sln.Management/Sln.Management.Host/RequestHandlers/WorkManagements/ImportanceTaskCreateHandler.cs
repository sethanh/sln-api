using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class ImportanceTaskCreateHandler(ImportanceTaskService importanceTaskService) : IRequestHandler<ImportanceTaskCreateRequest, ImportanceTaskCreateResponse>
{
    public Task<ImportanceTaskCreateResponse> Handle(ImportanceTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return importanceTaskService.Create(request);
    }
}