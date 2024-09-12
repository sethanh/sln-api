using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialExpenditureCreateHandler(FinancialExpenditureService financialExpenditureService) : IRequestHandler<FinancialExpenditureCreateRequest, FinancialExpenditureCreateResponse>
{
    public Task<FinancialExpenditureCreateResponse> Handle(FinancialExpenditureCreateRequest request, CancellationToken cancellationToken)
    {
        return financialExpenditureService.Create(request);
    }
}