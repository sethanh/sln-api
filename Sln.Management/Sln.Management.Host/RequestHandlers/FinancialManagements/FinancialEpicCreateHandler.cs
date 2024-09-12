using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialEpicCreateHandler(FinancialEpicService financialEpicService) : IRequestHandler<FinancialEpicCreateRequest, FinancialEpicCreateResponse>
{
    public Task<FinancialEpicCreateResponse> Handle(FinancialEpicCreateRequest request, CancellationToken cancellationToken)
    {
        return financialEpicService.Create(request);
    }
}