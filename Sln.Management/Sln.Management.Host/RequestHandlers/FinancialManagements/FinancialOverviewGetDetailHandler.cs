using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialOverviewGetDetailHandler(FinancialOverviewService financialOverviewService) : IRequestHandler<FinancialOverviewGetDetailRequest, FinancialOverviewGetDetailResponse>
{
    public Task<FinancialOverviewGetDetailResponse> Handle(FinancialOverviewGetDetailRequest request, CancellationToken cancellationToken)
    {
        return financialOverviewService.GetDetail(request);
    }
}
