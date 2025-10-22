using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDetailGetAllHandler(SaleDetailService saleDetailService) : IRequestHandler<SaleDetailGetAllRequest, SaleDetailGetAllResponse>
{
    public Task<SaleDetailGetAllResponse> Handle(SaleDetailGetAllRequest request, CancellationToken cancellationToken)
    {
        return saleDetailService.GetAll(request);
    }
}
