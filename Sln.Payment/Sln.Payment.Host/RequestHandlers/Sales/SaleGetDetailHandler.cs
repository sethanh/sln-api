using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleGetDetailHandler(SaleService saleService) : IRequestHandler<SaleGetDetailRequest, SaleGetDetailResponse>
{
    public Task<SaleGetDetailResponse> Handle(SaleGetDetailRequest request, CancellationToken cancellationToken)
    {
        return saleService.GetDetail(request);
    }
}
