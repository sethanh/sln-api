using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialOverviewCreateHandler(FinancialOverviewService financialOverviewService) : IRequestHandler<FinancialOverviewCreateRequest, FinancialOverviewCreateResponse>
{
    public Task<FinancialOverviewCreateResponse> Handle(FinancialOverviewCreateRequest request, CancellationToken cancellationToken)
    {
        return financialOverviewService.Create(request);
    }
}