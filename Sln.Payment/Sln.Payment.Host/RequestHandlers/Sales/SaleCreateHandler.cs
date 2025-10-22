using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleCreateHandler(SaleService saleService) : IRequestHandler<SaleCreateRequest, SaleCreateResponse>
{
    public Task<SaleCreateResponse> Handle(SaleCreateRequest request, CancellationToken cancellationToken)
    {
        return saleService.Create(request);
    }
}