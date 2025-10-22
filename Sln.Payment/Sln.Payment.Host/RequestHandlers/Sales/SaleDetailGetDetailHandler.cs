using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDetailGetDetailHandler(SaleDetailService saleDetailService) : IRequestHandler<SaleDetailGetDetailRequest, SaleDetailGetDetailResponse>
{
    public Task<SaleDetailGetDetailResponse> Handle(SaleDetailGetDetailRequest request, CancellationToken cancellationToken)
    {
        return saleDetailService.GetDetail(request);
    }
}
