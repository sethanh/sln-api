using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialEpicDeleteHandler(FinancialEpicService financialEpicService) : IRequestHandler<FinancialEpicDeleteRequest>
{
    public Task Handle(FinancialEpicDeleteRequest request, CancellationToken cancellationToken)
    {
        return financialEpicService.Delete(request);
    }
}
