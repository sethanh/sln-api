using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleUpdateHandler(SaleService saleService) : IRequestHandler<SaleUpdateRequest, SaleUpdateResponse>
{
    public Task<SaleUpdateResponse> Handle(SaleUpdateRequest request, CancellationToken cancellationToken)
    {
        return saleService.Update(request);
    }
}