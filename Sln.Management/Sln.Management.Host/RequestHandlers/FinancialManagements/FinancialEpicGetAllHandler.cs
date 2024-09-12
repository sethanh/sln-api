using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialEpicGetAllHandler(FinancialEpicService financialEpicService) : IRequestHandler<FinancialEpicGetAllRequest, FinancialEpicGetAllResponse>
{
    public Task<FinancialEpicGetAllResponse> Handle(FinancialEpicGetAllRequest request, CancellationToken cancellationToken)
    {
        return financialEpicService.GetAll(request);
    }
}
