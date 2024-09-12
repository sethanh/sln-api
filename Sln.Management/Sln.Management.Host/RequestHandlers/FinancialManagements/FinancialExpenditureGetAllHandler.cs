using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialExpenditureGetAllHandler(FinancialExpenditureService financialExpenditureService) : IRequestHandler<FinancialExpenditureGetAllRequest, FinancialExpenditureGetAllResponse>
{
    public Task<FinancialExpenditureGetAllResponse> Handle(FinancialExpenditureGetAllRequest request, CancellationToken cancellationToken)
    {
        return financialExpenditureService.GetAll(request);
    }
}
