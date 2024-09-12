using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialExpenditureGetDetailHandler(FinancialExpenditureService financialExpenditureService) : IRequestHandler<FinancialExpenditureGetDetailRequest, FinancialExpenditureGetDetailResponse>
{
    public Task<FinancialExpenditureGetDetailResponse> Handle(FinancialExpenditureGetDetailRequest request, CancellationToken cancellationToken)
    {
        return financialExpenditureService.GetDetail(request);
    }
}
