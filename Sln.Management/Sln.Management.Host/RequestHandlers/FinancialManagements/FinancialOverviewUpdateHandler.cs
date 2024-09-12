using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialOverviewUpdateHandler(FinancialOverviewService financialOverviewService) : IRequestHandler<FinancialOverviewUpdateRequest, FinancialOverviewUpdateResponse>
{
    public Task<FinancialOverviewUpdateResponse> Handle(FinancialOverviewUpdateRequest request, CancellationToken cancellationToken)
    {
        return financialOverviewService.Update(request);
    }
}