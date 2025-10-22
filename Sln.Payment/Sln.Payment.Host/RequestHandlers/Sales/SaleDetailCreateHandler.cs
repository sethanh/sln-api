using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDetailCreateHandler(SaleDetailService saleDetailService) : IRequestHandler<SaleDetailCreateRequest, SaleDetailCreateResponse>
{
    public Task<SaleDetailCreateResponse> Handle(SaleDetailCreateRequest request, CancellationToken cancellationToken)
    {
        return saleDetailService.Create(request);
    }
}