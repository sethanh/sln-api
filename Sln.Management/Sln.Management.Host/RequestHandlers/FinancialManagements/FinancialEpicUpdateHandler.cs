using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialEpicUpdateHandler(FinancialEpicService financialEpicService) : IRequestHandler<FinancialEpicUpdateRequest, FinancialEpicUpdateResponse>
{
    public Task<FinancialEpicUpdateResponse> Handle(FinancialEpicUpdateRequest request, CancellationToken cancellationToken)
    {
        return financialEpicService.Update(request);
    }
}