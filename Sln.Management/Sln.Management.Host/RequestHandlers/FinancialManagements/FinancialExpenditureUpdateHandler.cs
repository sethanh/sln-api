using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialExpenditureUpdateHandler(FinancialExpenditureService financialExpenditureService) : IRequestHandler<FinancialExpenditureUpdateRequest, FinancialExpenditureUpdateResponse>
{
    public Task<FinancialExpenditureUpdateResponse> Handle(FinancialExpenditureUpdateRequest request, CancellationToken cancellationToken)
    {
        return financialExpenditureService.Update(request);
    }
}