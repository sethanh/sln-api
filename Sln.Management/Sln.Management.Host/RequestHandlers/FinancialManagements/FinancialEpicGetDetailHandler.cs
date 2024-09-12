using MediatR;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Business.Services.FinancialManagements;

namespace Sln.Management.Host.RequestHandlers.FinancialManagements;

public class FinancialEpicGetDetailHandler(FinancialEpicService financialEpicService) : IRequestHandler<FinancialEpicGetDetailRequest, FinancialEpicGetDetailResponse>
{
    public Task<FinancialEpicGetDetailResponse> Handle(FinancialEpicGetDetailRequest request, CancellationToken cancellationToken)
    {
        return financialEpicService.GetDetail(request);
    }
}
