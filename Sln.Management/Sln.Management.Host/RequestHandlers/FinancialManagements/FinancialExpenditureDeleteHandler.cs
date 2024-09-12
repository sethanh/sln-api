using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialExpenditureDeleteHandler(FinancialExpenditureService financialExpenditureService) : IRequestHandler<FinancialExpenditureDeleteRequest>
{
    public Task Handle(FinancialExpenditureDeleteRequest request, CancellationToken cancellationToken)
    {
        return financialExpenditureService.Delete(request);
    }
}
