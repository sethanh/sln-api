using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialOverviewGetAllHandler(FinancialOverviewService financialOverviewService) : IRequestHandler<FinancialOverviewGetAllRequest, FinancialOverviewGetAllResponse>
{
    public Task<FinancialOverviewGetAllResponse> Handle(FinancialOverviewGetAllRequest request, CancellationToken cancellationToken)
    {
        return financialOverviewService.GetAll(request);
    }
}
