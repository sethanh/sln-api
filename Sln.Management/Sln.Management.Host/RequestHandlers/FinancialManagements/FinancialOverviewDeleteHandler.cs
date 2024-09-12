using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialOverviewDeleteHandler(FinancialOverviewService financialOverviewService) : IRequestHandler<FinancialOverviewDeleteRequest>
{
    public Task Handle(FinancialOverviewDeleteRequest request, CancellationToken cancellationToken)
    {
        return financialOverviewService.Delete(request);
    }
}
