using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDetailUpdateHandler(SaleDetailService saleDetailService) : IRequestHandler<SaleDetailUpdateRequest, SaleDetailUpdateResponse>
{
    public Task<SaleDetailUpdateResponse> Handle(SaleDetailUpdateRequest request, CancellationToken cancellationToken)
    {
        return saleDetailService.Update(request);
    }
}